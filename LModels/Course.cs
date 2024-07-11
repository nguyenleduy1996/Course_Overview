
using Microsoft.AspNetCore.Http;

namespace LModels
{
	public class Course
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int CourseDetailID { get; set; }

		[Required(ErrorMessage = "Title is required")]
		public string Title { get; set; }

		[Required]
		[DataType(DataType.MultilineText)]
		public string Description { get; set; }

		[Required]
		[Column(TypeName = "decimal(10,2)")]
		public decimal Fee { get; set; }

		public bool IsBasic { get; set; }       // Khóa cơ bản hoăcj nâng cao 

		[Required]
		[Range(1, int.MaxValue, ErrorMessage = "Duration must be at least 1 month")]
		public int DurationMonths { get; set; }          //Thời gian đào tạo 

		public string? ImagePath { get; set; }

		[NotMapped]
		public IFormFile? ImageFile { get; set; }

		public ICollection<LabSession>? LabSessions { get; set; }
		public ICollection<Question>? Questions { get; set; }
	}
}
