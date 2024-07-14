using Course_Overview.Areas.Admin.Repository;
using Course_Overview.Data;
using Microsoft.AspNetCore.Mvc;

namespace Course_Overview.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class StudentController : Controller
    {
        private readonly IStudentRepository _studentRepository;
        private readonly DatabaseContext _dbContext;

        public StudentController(IStudentRepository studentRepository, DatabaseContext dbContext)
        {
            _studentRepository = studentRepository;
            _dbContext = dbContext;
        }

        public async Task<IActionResult> Index()
        {
            var students = await _studentRepository.GetAllStudent();
            return View(students);
        }
    }
}
