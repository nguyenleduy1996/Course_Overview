

namespace LModels
{
    //Bảng điểm danh
    public class Attendance
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AttendanceID { get; set; }
        public int StudentID { get; set; }
        public int TopicID { get; set; }
        public DateTime Date { get; set; }
        public bool Status { get; set; }    //Trạng thái "Present", "Absent"
    }
}
