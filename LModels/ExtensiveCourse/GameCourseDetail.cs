using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LModels.ExtensiveCourse
{
	public class GameCourseDetail:Course
	{
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CourseID { get; set; }      // Vừa là khóa chính vừa là khóa phụ (Quan hệ 1:1 vs )

        [Required(ErrorMessage = "GameEngines is required")]
		public string GameEngines { get; set; } // Công cụ phát triển game

		[Required(ErrorMessage = "GameDesign is required")]
		public string GameDesign { get; set; } // Thiết kế game

		[Required(ErrorMessage = "ProgrammingLanguages is required")]
		public string ProgrammingLanguages { get; set; } // Ngôn ngữ lập trình game

		[Required(ErrorMessage = "GameDevelopmentProcess is required")]
		public string GameDevelopmentProcess { get; set; } // Quy trình phát triển game

        public Course? Course { get; set; }
    }
}
