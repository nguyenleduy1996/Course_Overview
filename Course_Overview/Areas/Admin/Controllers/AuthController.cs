using Course_Overview.Areas.Admin.Repository;
using Course_Overview.Areas.Admin.Service;
using Course_Overview.Areas.Admin.Viewmodels;
using Course_Overview.Helper;
using Course_Overview.Service;
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
		private readonly EmailService _emailService;

		public AuthController(IUserRepository userRepository,
			IPasswordHasher<User> passwordHasher,
			LoginService loginService,
			EmailService emailService
			)
		{
			_userRepository = userRepository;
			_passwordHasher = passwordHasher;
			_loginService = loginService;
			_emailService = emailService;

		}

		public async Task<IActionResult> Index()
		{
			var users = await _userRepository.GetAllUser();
			return View(users);
		}

		//Phương thức View Login
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

            //kiểm tra email đã đươcj xác thực hay chưa 
            if (user.IsNewUser && !user.EmailConfirmed)
            {
				TempData["ErrorMessage"] = "Please confirm your email before logging in.";
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

		//Phương thức đăng ký tài khoản
		public async Task<IActionResult> Register(User user, string password)
		{
			if (string.IsNullOrEmpty(password))
			{
				ModelState.AddModelError("Password", "Password is required.");
				return View(user);
			}

			user.Password = _passwordHasher.HashPassword(user, password);
			user.FailedAttempts = 0; // Khởi tạo số lần đăng nhập thất bại

			//Tạo ra 1 mã thông báo xác nhận email
			var token = Guid.NewGuid().ToString();
			user.EmailConfirmationToken = token;
			user.EmailConfirmed = false;
			user.IsNewUser = true;    // điều kiện này để user cần xác thực email trươc khi login

			await _userRepository.AddUser(user);

			//Gui thong bao ma xac nhan toi email
			var callbackUrl = Url.Action("ConfirmEmail", "Auth", new { token }, protocol: HttpContext.Request.Scheme);
			await _emailService.SendMail(user.Email, "Confirm your email", $"Please confirm your account by clicking this link: <a href='{callbackUrl}'>link</a>");
			TempData["SuccessMessage"] = "Registration successful. Please check your email to confirm your account.";

			return RedirectToAction("Login");
		}

		//Phương thưc xác nhận Email
		public async Task<IActionResult> ConfirmEmail(string token)
		{
			if (string.IsNullOrEmpty(token))
			{
				TempData["ErrorMessage"] = "Invalid token.";
				return RedirectToAction("Index");
			}

			try
			{
				var user = await _userRepository.GetUserByEmailConfirmationTokenAsync(token);
				if (user != null)
				{
					user.EmailConfirmed = true;
					user.EmailConfirmationToken = null;
					await _userRepository.UpdateUser(user);
					TempData["SuccessMessage"] = "Email confirmed successfully. You can now log in.";
					return RedirectToAction("Login");
				}

				TempData["ErrorMessage"] = "Invalid token.";
			}
			catch (Exception ex)
			{

				TempData["ErrorMessage"] = "An error occurred while confirming your email. Please try again later.";
			}

			return RedirectToAction("Index");
		}

		//Phương thức Logout
		public IActionResult Logout()
		{
			SessionHelper.ClearSession(HttpContext);
			return RedirectToAction("Login", "Auth");
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

		//Phương thức View ForgotPassword
		public IActionResult ForgotPassword()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> ForgotPassword(string email)
		{
			try
			{
				if (string.IsNullOrEmpty(email))
				{
					ModelState.AddModelError("Email", "Email is required.");
					return View();
				}

				var user = await _userRepository.GetUserByEmailAsync(email);
				if (user != null)
				{
					var token = Guid.NewGuid().ToString();  //Tạo mã Token duy nhất
					user.ResetPasswordToken = token;
					user.ResetPasswordTokenExpiration = DateTime.UtcNow.AddHours(1);   // Mã token hơpj lệ trong 1 giờ
					await _userRepository.UpdateUser(user);

					var callbackUrl = Url.Action("ResetPassword", "Auth", new { token }, protocol: Request.Scheme);
					await _emailService.SendMail(email, "Reset Password", $"Please reset your password by clicking <a href='{callbackUrl}'>here</a>.");
				}

				TempData["SuccessMessage"] = "If an account with that email address exists, a reset password link has been sent.";
				return RedirectToAction("Login");
			}
			catch (Exception ex)
			{
				ModelState.AddModelError("", ex.Message);
			}
			return View();
		}

		//Phương thức ResetPassword
		public IActionResult ResetPassword(string token)
		{
            if (string.IsNullOrEmpty(token))
            {
				TempData["ErrorMessage"] = "Invalid password reset token.";
				return RedirectToAction("Login");
			}

			var model = new ResetPasswordViewModel { Token = token };
			return View(model);
        }

		[HttpPost]
		public async Task<IActionResult> ResetPassword(ResetPasswordViewModel model)
		{
			if (ModelState.IsValid)
			{
				var user = await _userRepository.GetUserByResetPasswordTokenAsync(model.Token);
				if (user == null || user.ResetPasswordTokenExpiration < DateTime.UtcNow)
				{
					TempData["ErrorMessage"] = "Invalid or expired password reset token.";
					return RedirectToAction("Login");
				}

				user.Password = _passwordHasher.HashPassword(user, model.Password);
				user.ResetPasswordToken = null;
				user.ResetPasswordTokenExpiration = null;
				user.IsNewUser = false;    //Điều kiện này cho phép user khi reset password không cần xác thực email
				await _userRepository.UpdateUser(user);

				TempData["SuccessMessage"] = "Password reset successfully. You can now log in.";
				return RedirectToAction("Login");
			}

			return View(model);
		}

		//Phương thức delete
		public async Task<IActionResult>Delete(string email)
		{
			try
			{
				var userExisting = await _userRepository.GetUserByEmailAsync(email);
				if (userExisting == null)
				{
					return NotFound();
				}
				await _userRepository.DeleteUser(email);
				return RedirectToAction("Index", "Auth");
			}
			catch (Exception ex)
			{
				ModelState.AddModelError("", ex.Message);
			}
			return View();
		}
	}
}
