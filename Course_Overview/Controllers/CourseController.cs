using Course_Overview.Areas.Admin.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Course_Overview.Controllers
{
	public class CourseController : Controller
	{
		private readonly ICourserRepository _courserRepository;
		public CourseController(ICourserRepository courserRepository)
		{
			_courserRepository = courserRepository;
		}

		public async Task<IActionResult> Index()
		{
			var course = await _courserRepository.GetAllCourse();
			return View(course);
		}
	}
}
