
using Microsoft.AspNetCore.Http;

namespace LModels
{
	public class Course
	{
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CourseID { get; set; }

		[Required(ErrorMessage = "Course name is required")]
		public string CourseName { get; set; }

        public ICollection<CourseDetail>? CourseDetails { get; set; }

       

        

    }
}
