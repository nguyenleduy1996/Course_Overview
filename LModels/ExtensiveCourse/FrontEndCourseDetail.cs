using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LModels.ExtensiveCourse
{
	public class FrontEndCourseDetail:Course
	{
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CourseID { get; set; }     // Vừa là khóa chính vừa là khóa phụ (Quan hệ 1:1 vs Course)

        [Required(ErrorMessage = "Target Audience is required")]
		public string TargetAudience { get; set; } // Đối tượng

		[Required(ErrorMessage = "Technologies is required")]
		public string Technologies { get; set; } // Công nghệ sử dụng 

		[Required(ErrorMessage = "LearningObjectives is required")]
		public string LearningObjectives { get; set; } // Mục tiêu đào tạo

		[Required(ErrorMessage = "Curriculum is required")]
		public string Curriculum { get; set; } // Chương trình học

		[Required(ErrorMessage = "Demand is required")]
		public string Demand { get; set; } // Nhu cầu thị trường

		[Required(ErrorMessage = "Salary  is required")]
		public string Salary { get; set; } // Mức lương

        public Course? Course { get; set; }
    }
}
