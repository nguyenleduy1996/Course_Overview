using Course_Overview.Areas.Admin.Repository;
using Course_Overview.Data;
using LModels.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Course_Overview.Controllers
{
	public class CourseController : Controller
	{
		private readonly ICourserRepository _courserRepository;
		private readonly ITopicRepository _topicRepository;
		private readonly DatabaseContext _dbContext;
		public CourseController(ICourserRepository courserRepository,
								DatabaseContext dbContext,
								ITopicRepository topicRepository
		)
		{
			_courserRepository = courserRepository;
			_dbContext = dbContext;
			_topicRepository = topicRepository;
		}

		public async Task<IActionResult> Index()
		{
			var course = await _courserRepository.GetAllCourse();
			return View(course);
		}

		public async Task<IActionResult>CourseDetail(int id)
		{
			try
			{
				var course = await _courserRepository.GetOneCourse(id);
				if (course == null)
				{
					return NotFound();
				}

				var courses = await _courserRepository.GetAllCourse();
				if (courses == null)
				{
					return NotFound();
				}

				var topics = await _topicRepository.GetAllTopic();
                if (topics == null)
                {
					return NotFound();
                }

                var sliders = await _dbContext.Sliders.ToListAsync();
				int SliderId = 1;  // Đặt chỉ định cho = 1
				var viewModel = new CourseDetailViewModel
				{
					Course = course,
					Courses = courses.ToList(),
					Topics = topics.ToList(),
					Sliders = sliders.ToList(),
					SpecificSliderId = 3
				};

				return View(viewModel);
			}
			catch (Exception ex)
			{
			    ModelState.AddModelError("", ex.Message);
				return StatusCode(500, "Internal server error");
			}
		}
	}
}
