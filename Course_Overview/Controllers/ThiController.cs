using Course_Overview.Areas.Admin.Repository;
using Course_Overview.Data;
using LModels;
using LModels.ExModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Course_Overview.Controllers
{
	public class ThiController : Controller
	{
	
		private readonly DatabaseContext _dbContext;

		public ThiController(DatabaseContext dbContext)
		{
			_dbContext = dbContext;
		}

       
        public ActionResult Index(int ExamID)
        {
            var studentId = 1;

            

            var _Exams = _dbContext.EX_Exams.Where(x => x.ExamID == ExamID).FirstOrDefault();
            var adjustedEndTime = _Exams.TimeEnd?.AddMinutes(-_Exams.TotalMins);

            // Kiểm tra nếu thời gian hiện tại đã vượt quá thời gian kết thúc đã điều chỉnh
            if (adjustedEndTime < DateTime.Now && DateTime.Now < _Exams.TimeEnd)
            {
                var _ExamQuestions = _dbContext.EX_ExamQuestions
                                .Where(x => x.ExamID == ExamID)
                                .Include(x => x.Question) // Assuming the navigation property is named 'Question'
                                    .ThenInclude(q => q.Answers) // Assuming the navigation property in Question is named 'Answers'
                                .ToList();


                var _Subject = _dbContext.EX_Subjects.Where(x => x.SubjectID == _Exams.SubjectID).FirstOrDefault();
                var _Lession = _dbContext.EX_Lessons.Where(x => x.SubjectID == _Subject.SubjectID).ToList();
                var result = _dbContext.EX_StudentExamResults.Where(x => x.StudentID == studentId).ToList();
                ViewBag._Exams = _Exams;
                ViewBag._ExamQuestions = _ExamQuestions;
                ViewBag._Subject = _Subject;
                ViewBag._Lession = _Lession;
                ViewBag.result = result;
                return View();
            }
            else
            {
                return View("Expired");
            }
            
          
        }
        public ActionResult PartialList(int ExamID)
        {
            var studentId = 1;
            var _Exams = _dbContext.EX_Exams.Where(x => x.ExamID == ExamID).FirstOrDefault();
            var _ExamQuestions = _dbContext.EX_ExamQuestions
                                .Where(x => x.ExamID == ExamID)
                                .Include(x => x.Question) // Assuming the navigation property is named 'Question'
                                    .ThenInclude(q => q.Answers) // Assuming the navigation property in Question is named 'Answers'
                                .ToList();


            var _Subject = _dbContext.EX_Subjects.Where(x => x.SubjectID == _Exams.SubjectID).FirstOrDefault();
            var _Lession = _dbContext.EX_Lessons.Where(x => x.SubjectID == _Subject.SubjectID).ToList();
            var result = _dbContext.EX_StudentExamResults.Where(x => x.StudentID == studentId).ToList();
            ViewBag._Exams = _Exams;
            ViewBag._ExamQuestions = _ExamQuestions;
            ViewBag._Subject = _Subject;
            ViewBag._Lession = _Lession;
            ViewBag.result = result;
            return View();

        }
        //{ ExamID: ExamID, QuestionID: QuestionID, AnswerID: QuestionID },
        public ActionResult Submit(int ExamID, int QuestionID, int AnswerID)
        {
            try
            {
                var exam = _dbContext.EX_Exams.Where(x=>x.ExamID==ExamID).FirstOrDefault();
                if (exam.TimeEnd < DateTime.Now) 
                {
                    return Json(new { success = true, message = "Hết Giờ Làm Bài" });
                }

                var a = _dbContext.EX_StudentExamResults.Where(x=>x.ExamID==ExamID && x.StudentID == 1 && x.QuestionID == QuestionID).FirstOrDefault();
                if (a != null)
                {
                    if(a.StudentAnswers == AnswerID) 
                    {
                        return Json(new { success = true, message = "Bạn Đã chọn Đáp Án Này" });
                    }
                    else
                    {
                        a.StudentAnswers = AnswerID;
                        a.IsCorrect = checkTrue(AnswerID);
                        _dbContext.SaveChanges();
                        return Json(new { success = true, message = "Bạn Đã Thay Đổi Đáp Án" });
                    }
                }
                var _new =  new EX_StudentExamResult();
                _new.StudentID = 1;
                _new.QuestionID = QuestionID;
                _new.ExamID = ExamID;
                _new.StudentAnswers = AnswerID;
                _new.IsCorrect = checkTrue(AnswerID);
                _dbContext.EX_StudentExamResults.Add(_new);
                _dbContext.SaveChanges();
                return Json(new { success = true, message = "Succes" });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = "fail" });
            }
        }
        private bool checkTrue(int AnswersID)
        {
            var ans = _dbContext.EX_Answers.Where(x=>x.AnswerID == AnswersID).FirstOrDefault();
            return ans.IsCorrect;
        }
       



    }
}
