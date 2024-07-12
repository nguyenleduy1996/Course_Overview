

namespace LModels
{
    public class Schedule
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ScheduleID { get; set; }
        public int TopicID { get; set; }
        public string ClassID { get; set; }
        public string StartDate { get; set; }     //Ngày bắt đầu môn học 
        public string EndDate { get; set; }       //Ngày kết thúc môn học
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string RecurringDays { get; set; }     //Ví dụ: "Mon,Wed,Fri"


        public string Room { get; set; }
        public Topic? Topic {  get; set; } 
        public Class? Class { get; set; }
    }
}
