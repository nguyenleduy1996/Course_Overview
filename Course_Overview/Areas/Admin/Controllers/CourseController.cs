using Course_Overview.Areas.Admin.Repository;
using Course_Overview.Areas.Admin.Service;
using Microsoft.AspNetCore.Mvc;

namespace Course_Overview.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class CourseController : Controller
	{
		private readonly ICourserRepository _courseRepository;
		public CourseController(ICourserRepository courseRepository)
		{
            _courseRepository = courseRepository;
		}

		public async Task<IActionResult> Index()
		{
			var courses = await _courseRepository.GetAllCourse();
			return View(courses);
		}
	}
}
