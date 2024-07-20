using System.Text.Json;
using System.Text.Json.Serialization;
using Course_Overview.Areas.Admin.Repository;
using Course_Overview.Areas.Admin.Service;
using Course_Overview.Helper;
using LModels;
using LModels.ViewModels;
using Microsoft.AspNetCore.Mvc;


namespace Course_Overview.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CourseController : Controller
    {
        private readonly ICourserRepository _courseRepository;
        private readonly ICourseDetailRepository _courseDetailRepository;
        private readonly ITopicRepository _topicRepository;
        public CourseController(ICourserRepository courseRepository,
                                ICourseDetailRepository courseDetailRepository,
                                ITopicRepository topicRepository
            )
        {
            _courseRepository = courseRepository;
            _courseDetailRepository = courseDetailRepository;
            _topicRepository = topicRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Detail(int id)
        {
            // Lấy thông tin khóa học từ cơ sở dữ liệu bằng ID
            var course = await _courseRepository.GetOneCourse(id);

            // Nếu khóa học không tồn tại, trả về lỗi 404
            if (course == null)
            {
                return NotFound();
            }

            // Lấy các chi tiết của khóa học
            var courseDetails = await _courseDetailRepository.GetByCourseIdAsync(id);

            var viewModel = new CourseDetailShowViewModel
            {
                Course = course,
                CourseDetails = courseDetails.ToList()
            };

            // Trả về view với dữ liệu khóa học
            return View(viewModel);
        }

        public async Task<IActionResult> GetCourses()
        {
            var courses = await _courseRepository.GetAllCourse();
            var options = new JsonSerializerOptions
            {
                ReferenceHandler = ReferenceHandler.IgnoreCycles,
                WriteIndented = true
            };
            return Json(new { data = courses }, options);
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

        public async Task<IActionResult> Update(int id)
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

        [HttpPost]
        public async Task<IActionResult> Update(Course course)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (course.ImageFile != null)
                    {
                        var imagePath = await UploadFile.SaveImage("Courseimages", course.ImageFile);
                        if (!string.IsNullOrEmpty(imagePath))
                        {
                            if (!string.IsNullOrEmpty(course.ImagePath))
                            {
                                UploadFile.DeleteImage(course.ImagePath);
                            }

                            //Cập nhật đường dân mới vào model
                            course.ImagePath = imagePath;
                        }
                    }
                    await _courseRepository.UpdateCourse(course);
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
            }
            return View(course);
        }

        /* public async Task<IActionResult> Delete(int id)
         {
             try
             {
                 var courseExisting = await _courseRepository.GetOneCourse(id);
                 if (courseExisting == null)
                 {
                     return NotFound();
                 }
                 else
                 {
                     if (!string.IsNullOrEmpty(courseExisting.ImagePath))
                     {
                         UploadFile.DeleteImage(courseExisting.ImagePath);
                     }
                     await _courseRepository.DeleteCourse(id);
                     return RedirectToAction("Index");
                 }
             }
             catch (Exception ex)
             {
                 ModelState.AddModelError("", ex.Message);
             }
             return View();
         }*/

        /*public async Task<IActionResult> CreateDetail(int id)
        {
            var course = await _courseRepository.GetOneCourse(id);
            if (course == null || course.CourseType != "FullStackCourseDetail")
            {
                return NotFound("Course not found or not a FullStackCourseDetail type");
            }

            var model = new FullStackCourseDetailViewModel
            {
                CourseID = course.CourseID
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> CreateDetail(FullStackCourseDetailViewModel model)
        {
            if (ModelState.IsValid)
            {
                var courseExisting = await _courseRepository.GetOneCourse(model.CourseID);
                if (courseExisting == null)
                {
                    ModelState.AddModelError("", "Course not found.");
                    return NotFound();
                }

                if (courseExisting.CourseName == null)
                {
                    return NotFound();
                }

                if (courseExisting.CourseType != "FullStackCourseDetail" )
                {
                    ModelState.AddModelError("", "The CourseType must be 'FullStackCourseDetail' for this operation.");
                    return View(model);
                }

                var fullStackCourseDetail = new FullStackCourseDetail
                {
                    CourseID = model.CourseID,
                    Curriculum = model.Curriculum,
                    TargetAudience = model.TargetAudience,
                    Benefits = model.Benefits,
                    Certification = model.Certification
                };
                await _fullStackCourseDetailRepository.AddFullStackCourseDetail(fullStackCourseDetail);       
                return RedirectToAction("Index");
            }
            return View(model);
        }*/
    }
}