using System.Diagnostics;
using Course_Overview.Areas.Admin.Repository;
using Course_Overview.Models;
using LModels.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Course_Overview.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;
		private readonly ICourserRepository _courseRepository;
		private readonly ITeacherRepository _teacherRepository;

		public HomeController(ILogger<HomeController> logger, ICourserRepository courserRepository, ITeacherRepository teacherRepository )
		{
			_logger = logger;
			_courseRepository = courserRepository;
			_teacherRepository = teacherRepository;
		}

		public async Task<IActionResult> Index()
		{
			var  courseList = await _courseRepository.GetAllCourse();
			var  teacherList = await _teacherRepository.GetAllTeacher();

			// Sử dụng ViewModel để gửi cả danh sách Course và Teacher đến View
			var viewModel = new HomeIndexViewModel
			{
				Courses = courseList,
				Teachers = teacherList
			};
			return View(viewModel);
		}

		public IActionResult Privacy()
		{
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
