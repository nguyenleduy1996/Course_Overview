using Course_Overview.Areas.Admin.Repository;
using Course_Overview.Areas.Admin.Service;
using Course_Overview.Data;
using LModels;
using LModels.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace Course_Overview.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CourseDetailController : Controller
    {
        private readonly ICourseDetailRepository _courseDetailRepository;
        private readonly ICourserRepository _courseRepository;
        public CourseDetailController(ICourseDetailRepository courseDetailRepository, ICourserRepository courseRepository)
        {
            _courseDetailRepository = courseDetailRepository;
            _courseRepository = courseRepository;
        }
        public async Task<IActionResult> Index()
        {
            var courseDetails = await _courseDetailRepository.GetAllAsync();

            // Chuyển đổi từ CourseDetail sang CourseDetailViewModel
            var viewModel = courseDetails.Select(detail => new CourseDetailCreateViewModel
            {
                CourseID = detail.CourseID,
                DetailType = detail.DetailType,
                Curriculum = detail.Curriculum,
                TargetAudience = detail.TargetAudience,
                Benefits = detail.Benefits,
                Certification = detail.Certification,
                Technologies = detail.Technologies,
                LearningObjectives = detail.LearningObjectives,
                Demand = detail.Demand,
                Salary = detail.Salary,
                Languages = detail.Languages,
                Frameworks = detail.Frameworks,
                Databases = detail.Databases,
                Architecture = detail.Architecture,
                GameEngines = detail.GameEngines,
                GameDesign = detail.GameDesign,
                ProgrammingLanguages = detail.ProgrammingLanguages,
                GameDevelopmentProcess = detail.GameDevelopmentProcess
            });

            return View(viewModel);
        }

        public  async Task<IActionResult> Create(int id)
        {
			// Kiểm tra xem CourseID có tồn tại trong bảng Courses không
			var courseExists = await _courseRepository.GetAllCourse();
			if (!courseExists.Any(c => c.CourseID == id))
			{
				return NotFound(); // Hoặc xử lý lỗi phù hợp
			}

			var viewModel = new CourseDetailCreateViewModel
			{
				CourseID = id,
				DetailType = "FullStack" // Giá trị mặc định hoặc có thể chọn từ dropdown trong view
			};

			return View(viewModel);
		}

		[HttpPost]
		public async Task<IActionResult> Create(CourseDetailCreateViewModel model)
		{
			if (ModelState.IsValid)
			{
				// Kiểm tra xem CourseID có tồn tại trong bảng Courses không
				var courseExists = await _courseRepository.GetAllCourse();
				if (!courseExists.Any(c => c.CourseID == model.CourseID))
				{
					ModelState.AddModelError("CourseID", "CourseID không tồn tại.");
					return View(model);
				}

				var courseDetail = new CourseDetail
				{
					CourseID = model.CourseID,
					DetailType = model.DetailType,
					Curriculum = model.Curriculum,
					TargetAudience = model.TargetAudience,
					Benefits = model.Benefits,
					Certification = model.Certification,
					Technologies = model.Technologies,
					LearningObjectives = model.LearningObjectives,
					Demand = model.Demand,
					Salary = model.Salary,
					Languages = model.Languages,
					Frameworks = model.Frameworks,
					Databases = model.Databases,
					Architecture = model.Architecture,
					GameEngines = model.GameEngines,
					GameDesign = model.GameDesign,
					ProgrammingLanguages = model.ProgrammingLanguages,
					GameDevelopmentProcess = model.GameDevelopmentProcess
				};

				await _courseDetailRepository.AddAsync(courseDetail);
				return RedirectToAction("Index", "Course"); // Redirect đến trang danh sách khóa học hoặc trang chi tiết khóa học
			}

			return View(model);
		}


	}
}
