
using Microsoft.AspNetCore.Http;

namespace LModels
{
	public class Course
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int CourseID { get; set; }

		[Required(ErrorMessage = "Course Name is required")]
		public string CourseName { get; set; }

		[Required]
		[DataType(DataType.MultilineText)]
		public string Description { get; set; }

		[Required]
		[Column(TypeName = "decimal(10,2)")]
		public decimal Fee { get; set; }

		[Required]
		[Range(1, int.MaxValue, ErrorMessage = "Duration must be at least 1 month")]
		public int DurationMonths { get; set; }          //Thời gian đào tạo 

		public string? ImagePath { get; set; }

		[NotMapped]
		public IFormFile? ImageFile { get; set; }

		public ICollection<Topic>? Topics { get; set; }
	}
}
