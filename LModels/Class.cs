

namespace LModels
{
	public class Class
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int ClassID { get; set; }

		[Required(ErrorMessage = "Class name is required")]
		public string ClassName { get; set; }
		public int TeacherID { get; set; }
		public DateTime StartTime { get; set; }
		public DateTime EndTime { get; set; }

		[Required]
		[Column(TypeName = "decimal(10,2)")]
		public decimal Fee { get; set; }

		[Required]
		[RegularExpression("^(Basic|Advanced)$", ErrorMessage = "Invalid Segregated Class")]
		public string SegregatedClass { get; set; }  //Phân loai lớp

		public Teacher? Teacher { get; set; }
		public ICollection<ExamResult>? ExamResults { get; set; }

	}
}
