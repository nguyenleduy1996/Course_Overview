

namespace LModels
{
	public class Question
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int QuestionID { get; set; }
		public int CourseDetailID { get; set; }
		public int ExamID { get; set; }

		[Required]
		public string QuestionText { get; set; }    //Nội dung câu hỏi
		public string OptionA { get; set; }
		public string OptionB { get; set; }
		public string OptionC { get; set; }
		public string OptionD { get; set; }
		public string CorrectAnswer { get; set; }

		public CourseDetail? CourseDetail { get; set; }
		public EntranceExam? EntranceExam { get; set; }

		public ICollection<StudentExam> StudentExam { get; set;}
	}
}
