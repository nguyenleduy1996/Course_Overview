

namespace LModels
{
	public class StudentExam
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int StudentExamID { get; set; }
		public int StudentID { get; set; }
		public int ExamID { get; set; }
		public int QuestionID { get; set; }
		public string StudentAnswer { get; set; }

		public Student? Student { get; set; }
		public EntranceExam? EntranceExam { get; set; }
		public Question? Question { get; set; }
	}
}
