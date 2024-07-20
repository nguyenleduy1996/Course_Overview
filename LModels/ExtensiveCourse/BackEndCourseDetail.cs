using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LModels.ExtensiveCourse
{
	public class BackEndCourseDetail:Course
	{
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CourseID { get; set; }    // Vừa là khóa chính vừa là khóa phụ (Quan hệ 1:1 vs Course)

        [Required(ErrorMessage = "Languages is required")]
		public string Languages { get; set; } // Ngôn ngữ lập trình

		[Required(ErrorMessage = "Frameworks is required")]
		public string Frameworks { get; set; } // Frameworks sử dụng

		[Required(ErrorMessage = "Databases is required")]
		public string Databases { get; set; } // Cơ sở dữ liệu

		[Required(ErrorMessage = "Architecture is required")]
		public string Architecture { get; set; } // Kiến trúc phần mềm

        public Course? Course { get; set; }
    }
}
