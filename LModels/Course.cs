﻿

namespace LModels
{
	public class Course
	{
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CourseID { get; set; }

		[Required(ErrorMessage = "Course name is required")]
		public string CourseName { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        [Required]
		[Range(1, int.MaxValue, ErrorMessage = "Duration must be at least 1 month")]
		public int DurationMonths { get; set; }

        [Required]
        [Column(TypeName ="decimal(10,2)")]
        public decimal Fee { get; set; }
        public bool IsBasic { get; set; }
        public ICollection<LabSession> LabSessions { get; set; }
        public ICollection<Question> Questions { get; set; }
    }
}
