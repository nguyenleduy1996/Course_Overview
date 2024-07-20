using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LModels.ExtensiveCourse
{
	public class FullStackCourseDetail : Course
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int CourseID { get; set; }     // Vừa là khóa chính vừa là khóa phụ (Quan hệ 1:1 vs Course)

        [Required(ErrorMessage = "Curriculum is required")]
		public string Curriculum {  get; set; }   // Chương trình đào tạo
		
		[Required(ErrorMessage = "Target Audience is required")]
		public string TargetAudience { get; set; }   // Đối tượng tham gia

		[Required(ErrorMessage = "Benefits is required")]
		public string Benefits { get; set; } // Lợi thế chương trình

		[Required(ErrorMessage = "Certification is required")]
		public string Certification { get; set; } // Bằng cấp quốc tế

		public Course? Course { get; set; }
	}
}
