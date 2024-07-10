

namespace LModels
{
	public class LabSession
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int SessionID { get; set; }
		public int StudentID { get; set; }
		public int CourseID { get; set; }
		public bool OptedAtRegistration { get; set; }   //Đăng ký lúc đăng ký khóa học

		[Required]
		[Column(TypeName = "Decimal(10,2)")]
		public decimal Fee { get; set; }

		public Course? Course { get; set; }
		public Student? Student { get; set; }
	}
}
