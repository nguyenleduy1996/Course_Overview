

namespace LModels
{
	public class EntranceExam
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int ExamID { get; set; }
		public DateTime ExamDate { get; set; }

		[Required]
		[Column(TypeName = "decimal(10,2)")]
		public decimal Fee { get; set; }
		public string Status { get; set; }

		public ICollection<ExamResult> Results { get; set; }
		public ICollection<Question> Questions { get; set; }
		public ICollection<StudentExam> StudentExams { get; set; }
	}
}
