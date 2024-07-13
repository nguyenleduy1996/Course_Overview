
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

		public string? ImagePath { get; set; }

		[NotMapped]
		public IFormFile? ImageFile { get; set; }

		public ICollection<Topic>? Topics { get; set; }
	}
}
