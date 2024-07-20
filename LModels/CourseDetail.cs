using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LModels
{
    public class CourseDetail
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DetailID { get; set; }

        public int CourseID { get; set; }
        [ForeignKey("CourseID")]
        public Course Course { get; set; }

        public string DetailType { get; set; }

		// Fields for FullStack
		public string? Curriculum { get; set; }                           // Chương trình học
        public string? TargetAudience { get; set; }                       // Đối tượng
        public string? Benefits { get; set; }                             // Lợi thế chương trình
        public string? Certification { get; set; }                        // Bằng cấp quốc tế

		// Fields for FrontEnd
		public string? Technologies { get; set; }                           // Công nghệ sử dụng
        public string? LearningObjectives { get; set; }                    // Mục tiêu đào tạo
        public string? Demand { get; set; }                                // Nhu cầu thị trường
        public string? Salary { get; set; }                                // Mức lương

		// Fields for BackEnd
		public string? Languages { get; set; }                             // Ngôn ngữ lập trình
        public string? Frameworks { get; set; }                             // Frameworks sử dụng
        public string? Databases { get; set; }                             // Cơ sở dữ liệu
        public string? Architecture { get; set; }                          // Kiến trúc phần mềm

		// Fields for Game
		public string? GameEngines { get; set; }                           // Công cụ phát triển game
        public string? GameDesign { get; set; }                            // Thiết kế game
        public string? ProgrammingLanguages { get; set; }                  // Ngôn ngữ lập trình game
        public string? GameDevelopmentProcess { get; set; }                // Quy trình phát triển game
    }
}
