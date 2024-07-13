using Course_Overview.Areas.Admin.Repository;
using Course_Overview.Areas.Admin.Service;
using Course_Overview.Helper;
using LModels;
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

        public IActionResult Create()
        {
            return View();
        }

		[HttpPost]
        public async Task<IActionResult> Create(Course course, IFormFile imageFile)
        {
			try
			{
                if (ModelState.IsValid)
                {
                    if (imageFile != null && imageFile.Length > 0)
                    {
						string subFolder = "Courseimages";
						string saveImagePath = await UploadFile.SaveImage(subFolder, imageFile);
						course.ImagePath = saveImagePath;
                    }

					await _courseRepository.AddCourse(course);
					return RedirectToAction("Index");
                }
					
            }
			catch (Exception ex)
			{
				ModelState.AddModelError("", ex.Message);
			}
            return View(course);
        }

        public async Task<IActionResult> Edit(int id)
        {
			try
			{
				var courseExisting = await _courseRepository.GetOneCourse(id);
				if (courseExisting == null)
				{
					return NotFound("Not found");				
				}
                return View(courseExisting);
            }
			catch (Exception ex)
			{
                ModelState.AddModelError("", ex.Message);
				return View();
            }
    
        }
    }
}
