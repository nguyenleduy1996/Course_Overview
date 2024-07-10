

namespace LModels
{
	public class Question
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int QuestionID { get; set; }
		public int CourseID { get; set; }
		public int ExamID { get; set; }
		public string QuestionText { get; set; }    //Nội dung câu hỏi
		public string OptionA { get; set; }
		public string OptionB { get; set; }
		public string OptionC { get; set; }
		public string OptionD { get; set; }
		public string CorrectAnswer { get; set; }

		public Course? Course { get; set; }
		public EntranceExam? EntranceExam { get; set; }

		public ICollection<StudentExam> StudentExam { get; set;}
	}
}
