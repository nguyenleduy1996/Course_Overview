using Course_Overview.Areas.Admin.Repository;
using Course_Overview.Areas.Admin.Service;
using Course_Overview.Helper;
using LModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;
using Newtonsoft.Json;

namespace Course_Overview.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class AuthController : Controller
	{
		private readonly IUserRepository _userRepository;
		private readonly IPasswordHasher<User> _passwordHasher;      //Sử dụng Identity để Hash Password
		private readonly LoginService _loginService;
		private readonly ILogger<AuthController> _logger;
		public AuthController(IUserRepository userRepository, 
			IPasswordHasher<User> passwordHasher, 
			ILogger<AuthController> logger,
			LoginService loginService
			)
		{
			_userRepository = userRepository;
			_passwordHasher = passwordHasher;
			_loginService = loginService;
			_logger = logger;
		}

		public async Task<IActionResult> Login()
		{
			//Kiểm tra người dùng đã đăng nhập chưa , nếu đăng nhập rồi thì không thể đăng nhập tiếp 
			var userJson = SessionHelper.GetSession(HttpContext, "userSession");
			if (!string.IsNullOrEmpty(userJson))
			{
				return RedirectToAction("Index", "Course");
			}

			var message = TempData["ErrorMessage"] as string;
			ViewBag.ErrorMessage = message;
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Login(string? Email, string? Password)
		{
			if (string.IsNullOrEmpty(Email) || string.IsNullOrEmpty(Password))
			{
				TempData["ErrorMessage"] = "Email and Password are required.";
				return RedirectToAction("Login");
			}


			// Lấy người dùng từ repository
			var user = await _userRepository.GetUserByEmailAsync(Email);

			// Kiểm tra xem người dùng có bị khóa tạm thời không
			if (user == null || !await _loginService.CanAtTemptLogin(user))
			{
				TempData["ErrorMessage"] = "Too many failed login attempts. Please try again later.";
				return RedirectToAction("Login");
			}

			// Xác thực mật khẩu
			var passwordVerificationResult = _passwordHasher.VerifyHashedPassword(user, user.Password, Password);
			if (passwordVerificationResult != PasswordVerificationResult.Success)
			{
				await _loginService.RecordfailedAtTempt(user); // Ghi lại số lần đăng nhập thất bại
				TempData["ErrorMessage"] = "Email or password invalid.";
				return RedirectToAction("Login");
			}

			// Đăng nhập thành công
			await _loginService.ResetAtTempts(user);   // Đăng nhập thành công thì reset lại số lần đăng nhập về 0


			// Khi đăng nhâp cần lưu trư thông tin user vào Session lên cần chuyển đổi thành JSON để làm việc vì Session chỉ hỗ trợ lưu trữ JSON  mà không lưu trữ đối tuọng
			var userJson = JsonConvert.SerializeObject(user);

			// Lưu thông tin user vào session
			SessionHelper.SetSession(HttpContext, "userSession", userJson);

			if (user.Role == "Admin")
			{
				return RedirectToAction("Index", "Course");
			}
			else
			{
				return RedirectToAction("Create", "User");
			}


		}

		public async Task<IActionResult> Register(User user, string password)
		{
			if (string.IsNullOrEmpty(password))
			{
				ModelState.AddModelError("Password", "Password is required.");
				return View(user);
			}

			user.Password = _passwordHasher.HashPassword(user, password);
			user.FailedAttempts = 0; // Khởi tạo số lần đăng nhập thất bại
			await _userRepository.AddUser(user);
			return RedirectToAction("Login");
		}

		public IActionResult Logout()
		{
			SessionHelper.ClearSession(HttpContext);
			return RedirectToAction("Login", "Auth");
		}


		public async Task<IActionResult> Index()
		{
			var users = await _userRepository.GetAllUser();
			return View(users);
		}

		// Phương thức mở khóa tài khoản
		[HttpPost]
		public async Task<IActionResult> UnlockAccount(string email)
		{
			if (string.IsNullOrEmpty(email))
			{
				TempData["ErrorMessage"] = "Email is required.";
				return RedirectToAction("Index"); // Redirect về trang danh sách người dùng
			}

			var user = await _userRepository.GetUserByEmailAsync(email);

			if (user == null)
			{
				TempData["ErrorMessage"] = "User not found.";
				return RedirectToAction("Index"); // Redirect về trang danh sách người dùng
			}

			// Mở khóa tài khoản
			user.LockoutEnd = null; // Reset thời gian khóa
			user.FailedAttempts = 0; // Reset số lần đăng nhập thất bại

			await _userRepository.UpdateUser(user); // Cập nhật thông tin người dùng vào cơ sở dữ liệu

			TempData["SuccessMessage"] = "Account unlocked successfully.";
			return RedirectToAction("Index"); // Redirect về trang danh sách người dùng
		}
	}
}
