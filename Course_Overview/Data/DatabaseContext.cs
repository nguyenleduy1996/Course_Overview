using LModels;
using Microsoft.EntityFrameworkCore;

namespace Course_Overview.Data
{
	public class DatabaseContext:DbContext
	{
		public DatabaseContext(DbContextOptions options) : base(options) { }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			//Xây dựng mối quan hệ từ bảng Student
			modelBuilder.Entity<Student>()
				.HasMany(s => s.LabSessions)
				.WithOne(l => l.Student)
				.HasForeignKey(l => l.StudentID)
			    .OnDelete(DeleteBehavior.Restrict); // Tránh vòng lặp
			 
			modelBuilder.Entity<Student>()
				.HasMany(s => s.StudentExams)
				.WithOne(se => se.Student)
				.HasForeignKey(se => se.StudentID)
				.OnDelete(DeleteBehavior.Restrict); // Tránh vòng lặp

			modelBuilder.Entity<Student>()
				.HasMany(s => s.Payments)
				.WithOne(p => p.Student)
				.HasForeignKey(p => p.StudentID)
				.OnDelete(DeleteBehavior.Restrict); // Tránh vòng lặp

			modelBuilder.Entity<Student>()
				.HasMany(s => s.ExamResults)
				.WithOne(er => er.Student)
				.HasForeignKey(er => er.StudentID)
				.OnDelete(DeleteBehavior.Restrict); // Tránh vòng lặp

			//Xây dựng mối quan hệ từ bảng EntranceExam
			modelBuilder.Entity<EntranceExam>()
				.HasMany(ee => ee.Results)
				.WithOne(er => er.EntranceExam)
				.HasForeignKey(er => er.ExamID)
				.OnDelete(DeleteBehavior.Restrict); // Tránh vòng lặp

			modelBuilder.Entity<EntranceExam>()
				.HasMany(ee => ee.Questions)
				.WithOne(q => q.EntranceExam)
				.HasForeignKey(q => q.ExamID)
				.OnDelete(DeleteBehavior.Restrict); // Tránh vòng lặp

			modelBuilder.Entity<EntranceExam>()
				.HasMany(ee => ee.StudentExams)
				.WithOne(sx => sx.EntranceExam)
				.HasForeignKey(sx => sx.ExamID)
				.OnDelete(DeleteBehavior.Restrict); // Tránh vòng lặp

			//Xây dựng mối quan hệ từ bảng Course
			modelBuilder.Entity<Course>()
				.HasMany(c => c.Questions)
				.WithOne(q => q.Course)
				.HasForeignKey(q => q.CourseID)
				.OnDelete(DeleteBehavior.Restrict); // Tránh vòng lặp

			modelBuilder.Entity<Course>()
				.HasMany(c => c.LabSessions)
				.WithOne(ls => ls.Course)
				.HasForeignKey(ls => ls.CourseID)
				.OnDelete(DeleteBehavior.Restrict); // Tránh vòng lặp

			//Xây dựng mối quan hệ từ bảng Question
			modelBuilder.Entity<Question>()
				.HasMany(q => q.StudentExam)
				.WithOne(se => se.Question)
				.HasForeignKey(se => se.QuestionID)
				.OnDelete(DeleteBehavior.Restrict); // Tránh vòng lặp
		}

		public DbSet<Course> Courses { get; set; }
		public DbSet<EntranceExam> EntranceExams { get; set; }
		public DbSet<ExamResult> ExamResults { get; set; }
		public DbSet<FAQ> FAQs { get; set; }
		public DbSet<LabSession> LabSessions { get; set; }
		public DbSet<Student> Students { get; set; }
		public DbSet<Payment> Payments { get; set; }
		public DbSet<Question> Questions { get; set; }
		public DbSet<StudentExam> StudentExams { get; set; }
		public DbSet<ContactInfo> ContactInfos { get; set; }
	}
}
