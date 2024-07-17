using System.Diagnostics;
using Course_Overview.Areas.Admin.Repository;
using Course_Overview.Data;
using Course_Overview.Models;
using LModels.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Course_Overview.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;
		private readonly ICourserRepository _courseRepository;
		private readonly ITeacherRepository _teacherRepository;
		private readonly ITopicRepository _topicRepository;
		private readonly DatabaseContext _dbContext;

		public HomeController(ILogger<HomeController> logger,
			ICourserRepository courserRepository, 
			ITeacherRepository teacherRepository,
			ITopicRepository topicRepository,
			DatabaseContext dbContext
			)
		{
			_logger = logger;
			_courseRepository = courserRepository;
			_teacherRepository = teacherRepository;
			_dbContext = dbContext;
			_topicRepository = topicRepository;
		}

		public async Task<IActionResult> Index()
		{
			var  courseList = await _courseRepository.GetAllCourse();
			var  topicList = await _topicRepository.GetAllTopic();
			var  teacherList = await _teacherRepository.GetAllTeacher();
			var  sliderList = await _dbContext.Sliders.Where(s => s.Status).ToListAsync();	
			var  serviceList = await _dbContext.Services.ToListAsync();	

			// Sử dụng ViewModel để gửi cả danh sách Course và Teacher đến View
			var viewModel = new HomeIndexViewModel
			{
				Courses = courseList,
				Topics = topicList,
				Teachers = teacherList,
				Sliders = sliderList,
				Services = serviceList
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
