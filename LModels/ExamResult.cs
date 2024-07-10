

namespace LModels
{
	public class ExamResult
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int ResultID { get; set; }
		public int StudentID { get; set; }
		public int ExamID { get; set; }
		public int Marks { get; set; }

		[Required]
		public string SegregatedClass { get; set; }  //Phân loai lớp

		[Required]
		[Column(TypeName = "decimal(10,2)")]
		public decimal Fee { get; set; }

		public Student? Student { get; set; }
		public EntranceExam? EntranceExam { get; set; }
	}
}
