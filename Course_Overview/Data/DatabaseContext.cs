using LModels;
using LModels.Client;
using Microsoft.EntityFrameworkCore;

namespace Course_Overview.Data
{
	public class DatabaseContext : DbContext
	{
		public DatabaseContext(DbContextOptions options) : base(options) { }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			// Cấu hình Bảng Student cho 2 trường là duy nhất 
			modelBuilder.Entity<Student>()
				.HasIndex(s => s.Email)
				.IsUnique();

			modelBuilder.Entity<Student>()
				.HasIndex(s => s.Phone)
				.IsUnique();

			// Cấu hình Bảng Teacher cho 2 trường là duy nhất 
			modelBuilder.Entity<Teacher>()
				.HasIndex(t => t.Email)
				.IsUnique();

			modelBuilder.Entity<Teacher>()
				.HasIndex(t => t.Phone)
				.IsUnique();

			// Cấu hình Bảng ContacInfo cho 2 trường là duy nhất 
			modelBuilder.Entity<Contact>()
				.HasIndex(ci => ci.Phone)
				.IsUnique();

			modelBuilder.Entity<Topic>()
				.HasOne(t => t.Course)
				.WithMany(c => c.Topics)
				.HasForeignKey(t => t.CourseID);

            // Cấu hình mối quan hệ giữa Course và Topic
            modelBuilder.Entity<Topic>()
                .HasOne(t => t.Course)
                .WithMany(c => c.Topics)
                .HasForeignKey(t => t.CourseID);        

        }

		public DbSet<Course> Courses { get; set; }      //Bảng cho tiết khóa học (Java)
        public DbSet<Topic> Topics { get; set; }      //Bảng chủ đề khóa học (Java introdule)
		public DbSet<EntranceExam> EntranceExams { get; set; }      // Bảng kỳ thi tuyển sinh
		public DbSet<ExamResult> ExamResults { get; set; }          //Bảng lưu kết quả thi, phân lớp của học viên 
		public DbSet<FAQ> FAQs { get; set; }                        //Bảng câu hỏi thường gặp 
		public DbSet<Class> Classes { get; set; }                   //Bảng lớp học
		public DbSet<LabSession> LabSessions { get; set; }          //Bảng phòng Lab
		public DbSet<Student> Students { get; set; }                //Bảng học viên
		public DbSet<Teacher> Teachers { get; set; }                //Bảng giáo viên
		public DbSet<Payment> Payments { get; set; }                //Bảng thanh toán 
		public DbSet<Question> Questions { get; set; }              //Bảng lưu câu hỏi cho sinh viên làm bài thi
		public DbSet<Answer> Answers { get; set; }        //Bảng lưu câu trả lời của sinh viên khi làm bài thi
		public DbSet<Contact> Contacts { get; set; }
		public DbSet<Attendance> Attendances { get; set; }
		public DbSet<Admin> Admin { get; set; }
		public DbSet<Schedule> Schedules { get; set; }
		public DbSet<SubjectScores> SubjectScores { get; set; }
		public DbSet<Slider> Sliders { get; set; }                    //Bảng Slider
		public DbSet<Services> Services { get; set; }                    //Bảng Service
	}
}
