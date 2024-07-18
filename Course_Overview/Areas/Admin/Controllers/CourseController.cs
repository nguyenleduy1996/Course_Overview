using System.Text.Json;
using System.Text.Json.Serialization;
using Course_Overview.Areas.Admin.Repository;
using Course_Overview.Areas.Admin.Service;
using Course_Overview.Helper;
using LModels;
using Microsoft.AspNetCore.Mvc;
using X.PagedList.Extensions;

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
            return View();
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
    }
}