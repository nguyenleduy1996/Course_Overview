

namespace LModels
{
	public class ExamResult
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int ResultID { get; set; }
		public int StudentID { get; set; }
		public int ExamID { get; set; }
		public int ClassID { get; set; }

		[Required]
		[Range(0, 10, ErrorMessage = "Mark must be between from 0 to 10")]
		public double Marks { get; set; }               //Điểm số

		public DateTime ExamDate { get; set; }       // Ngày thực hiện kỳ thi

		[Required]
		[RegularExpression("^(Processed|No process|Processing)$", ErrorMessage = "Invalid Result Status")]
		public string ResultStatus { get; set; }     // Trạng thái kết quả (Đã xử lý , chưa xử lý , Đang xử lý )

		public Student? Student { get; set; }
		public EntranceExam? EntranceExam { get; set; }
		public Class? Class { get; set; }
	}
}
