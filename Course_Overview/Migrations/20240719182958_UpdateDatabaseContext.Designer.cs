﻿// <auto-generated />
using System;
using Course_Overview.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Course_Overview.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20240719182958_UpdateDatabaseContext")]
    partial class UpdateDatabaseContext
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("LModels.Admin", b =>
                {
                    b.Property<int>("AdminID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AdminID"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AdminID");

                    b.ToTable("Admin");
                });

            modelBuilder.Entity("LModels.Answer", b =>
                {
                    b.Property<int>("AnswerID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AnswerID"));

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("QuestionID")
                        .HasColumnType("int");

                    b.HasKey("AnswerID");

                    b.ToTable("Answers");
                });

            modelBuilder.Entity("LModels.Attendance", b =>
                {
                    b.Property<int>("AttendanceID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AttendanceID"));

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.Property<int>("StudentID")
                        .HasColumnType("int");

                    b.Property<int>("TopicID")
                        .HasColumnType("int");

                    b.HasKey("AttendanceID");

                    b.ToTable("Attendances");
                });

            modelBuilder.Entity("LModels.Class", b =>
                {
                    b.Property<int>("ClassID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ClassID"));

                    b.Property<string>("ClassName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClassType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Fee")
                        .HasColumnType("decimal(10,2)");

                    b.Property<int>("TeacherID")
                        .HasColumnType("int");

                    b.HasKey("ClassID");

                    b.HasIndex("TeacherID");

                    b.ToTable("Classes");
                });

            modelBuilder.Entity("LModels.Client.Services", b =>
                {
                    b.Property<int>("ServiceID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ServiceID"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Icon")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ServiceID");

                    b.ToTable("Services");
                });

            modelBuilder.Entity("LModels.Client.Slider", b =>
                {
                    b.Property<int>("SliderID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SliderID"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImagePath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SliderID");

                    b.ToTable("Sliders");
                });

            modelBuilder.Entity("LModels.Contact", b =>
                {
                    b.Property<int>("ContactID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ContactID"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BranchName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("ContactID");

                    b.HasIndex("Phone")
                        .IsUnique();

                    b.ToTable("Contacts");
                });

            modelBuilder.Entity("LModels.Course", b =>
                {
                    b.Property<int>("CourseID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CourseID"));

                    b.Property<string>("CourseName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CourseType")
                        .IsRequired()
                        .HasMaxLength(21)
                        .HasColumnType("nvarchar(21)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImagePath")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CourseID");

                    b.ToTable("Courses");

                    b.HasDiscriminator<string>("CourseType").HasValue("Course");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("LModels.EntranceExam", b =>
                {
                    b.Property<int>("ExamID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ExamID"));

                    b.Property<DateTime>("EndTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("ExamDate")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("Fee")
                        .HasColumnType("decimal(10,2)");

                    b.Property<DateTime>("StartTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ExamID");

                    b.ToTable("EntranceExams");
                });

            modelBuilder.Entity("LModels.ExamResult", b =>
                {
                    b.Property<int>("ResultID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ResultID"));

                    b.Property<int>("ClassID")
                        .HasColumnType("int");

                    b.Property<int?>("EntranceExamExamID")
                        .HasColumnType("int");

                    b.Property<int>("ExamID")
                        .HasColumnType("int");

                    b.Property<double>("Marks")
                        .HasColumnType("float");

                    b.Property<string>("PaymentStatus")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("StudentID")
                        .HasColumnType("int");

                    b.HasKey("ResultID");

                    b.HasIndex("ClassID");

                    b.HasIndex("EntranceExamExamID");

                    b.HasIndex("StudentID");

                    b.ToTable("ExamResults");
                });

            modelBuilder.Entity("LModels.FAQ", b =>
                {
                    b.Property<int>("FAQID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("FAQID"));

                    b.Property<string>("Answer")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<string>("Question")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("FAQID");

                    b.ToTable("FAQs");
                });

            modelBuilder.Entity("LModels.LabSession", b =>
                {
                    b.Property<int>("SessionID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SessionID"));

                    b.Property<int>("CourseID")
                        .HasColumnType("int");

                    b.Property<DateTime>("EndTime")
                        .HasColumnType("datetime2");

                    b.Property<bool>("OptedAtRegistration")
                        .HasColumnType("bit");

                    b.Property<DateTime>("StartTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("StudentID")
                        .HasColumnType("int");

                    b.Property<int>("TeacherID")
                        .HasColumnType("int");

                    b.HasKey("SessionID");

                    b.HasIndex("CourseID");

                    b.HasIndex("StudentID");

                    b.HasIndex("TeacherID");

                    b.ToTable("LabSessions");
                });

            modelBuilder.Entity("LModels.Payment", b =>
                {
                    b.Property<int>("PaymentID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PaymentID"));

                    b.Property<decimal>("Amount")
                        .HasColumnType("Decimal(10,2)");

                    b.Property<DateTime>("PaymentDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("PaymentMethod")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ReceiptNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("StudentID")
                        .HasColumnType("int");

                    b.HasKey("PaymentID");

                    b.HasIndex("StudentID");

                    b.ToTable("Payments");
                });

            modelBuilder.Entity("LModels.Question", b =>
                {
                    b.Property<int>("QuestionID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("QuestionID"));

                    b.Property<int>("CorrectAnswerID")
                        .HasColumnType("int");

                    b.Property<string>("QuestionText")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("QuestionID");

                    b.ToTable("Questions");
                });

            modelBuilder.Entity("LModels.Schedule", b =>
                {
                    b.Property<int>("ScheduleID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ScheduleID"));

                    b.Property<int>("ClassID")
                        .HasColumnType("int");

                    b.Property<string>("EndDate")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("EndTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("RecurringDays")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Room")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StartDate")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("StartTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("TopicID")
                        .HasColumnType("int");

                    b.HasKey("ScheduleID");

                    b.HasIndex("ClassID");

                    b.HasIndex("TopicID");

                    b.ToTable("Schedules");
                });

            modelBuilder.Entity("LModels.Student", b =>
                {
                    b.Property<int>("StudentID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("StudentID"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("IdentityCard")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImagePath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("StudentID");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.HasIndex("Phone")
                        .IsUnique();

                    b.ToTable("Students");
                });

            modelBuilder.Entity("LModels.SubjectScores", b =>
                {
                    b.Property<int>("SubjectScoresID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SubjectScoresID"));

                    b.Property<decimal>("Mark")
                        .HasColumnType("Decimal(10,2)");

                    b.Property<int>("StudentID")
                        .HasColumnType("int");

                    b.Property<int>("TopicID")
                        .HasColumnType("int");

                    b.HasKey("SubjectScoresID");

                    b.HasIndex("StudentID");

                    b.HasIndex("TopicID");

                    b.ToTable("SubjectScores");
                });

            modelBuilder.Entity("LModels.Teacher", b =>
                {
                    b.Property<int>("TeacherID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TeacherID"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImagePath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("TeacherCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TeacherID");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.HasIndex("Phone")
                        .IsUnique();

                    b.ToTable("Teachers");
                });

            modelBuilder.Entity("LModels.Topic", b =>
                {
                    b.Property<int>("TopicID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TopicID"));

                    b.Property<int>("CourseID")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImagePath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TopicName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TopicID");

                    b.HasIndex("CourseID");

                    b.ToTable("Topics");
                });

            modelBuilder.Entity("LModels.ExtensiveCourse.BackEndCourseDetail", b =>
                {
                    b.HasBaseType("LModels.Course");

                    b.Property<string>("Architecture")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Databases")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Frameworks")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Languages")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasDiscriminator().HasValue("BackEndCourseDetail");
                });

            modelBuilder.Entity("LModels.ExtensiveCourse.FrontEndCourseDetail", b =>
                {
                    b.HasBaseType("LModels.Course");

                    b.Property<string>("Curriculum")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Demand")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LearningObjectives")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Salary")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TargetAudience")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Technologies")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasDiscriminator().HasValue("FrontEndCourseDetail");
                });

            modelBuilder.Entity("LModels.ExtensiveCourse.FullStackCourseDetail", b =>
                {
                    b.HasBaseType("LModels.Course");

                    b.Property<string>("Benefits")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Certification")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Curriculum")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TargetAudience")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.ToTable("Courses", t =>
                        {
                            t.Property("Curriculum")
                                .HasColumnName("FullStackCourseDetail_Curriculum");

                            t.Property("TargetAudience")
                                .HasColumnName("FullStackCourseDetail_TargetAudience");
                        });

                    b.HasDiscriminator().HasValue("FullStackCourseDetail");
                });

            modelBuilder.Entity("LModels.ExtensiveCourse.GameCourseDetail", b =>
                {
                    b.HasBaseType("LModels.Course");

                    b.Property<string>("GameDesign")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GameDevelopmentProcess")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GameEngines")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProgrammingLanguages")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasDiscriminator().HasValue("GameCourseDetail");
                });

            modelBuilder.Entity("LModels.Class", b =>
                {
                    b.HasOne("LModels.Teacher", "Teacher")
                        .WithMany("Classes")
                        .HasForeignKey("TeacherID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Teacher");
                });

            modelBuilder.Entity("LModels.ExamResult", b =>
                {
                    b.HasOne("LModels.Class", "Class")
                        .WithMany("ExamResults")
                        .HasForeignKey("ClassID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LModels.EntranceExam", "EntranceExam")
                        .WithMany("ExamResults")
                        .HasForeignKey("EntranceExamExamID");

                    b.HasOne("LModels.Student", null)
                        .WithMany("ExamResults")
                        .HasForeignKey("StudentID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Class");

                    b.Navigation("EntranceExam");
                });

            modelBuilder.Entity("LModels.LabSession", b =>
                {
                    b.HasOne("LModels.Course", "Course")
                        .WithMany()
                        .HasForeignKey("CourseID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LModels.Student", null)
                        .WithMany("LabSessions")
                        .HasForeignKey("StudentID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LModels.Teacher", "Teacher")
                        .WithMany("LabSessions")
                        .HasForeignKey("TeacherID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");

                    b.Navigation("Teacher");
                });

            modelBuilder.Entity("LModels.Payment", b =>
                {
                    b.HasOne("LModels.Student", null)
                        .WithMany("Payments")
                        .HasForeignKey("StudentID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("LModels.Schedule", b =>
                {
                    b.HasOne("LModels.Class", "Class")
                        .WithMany("Schedules")
                        .HasForeignKey("ClassID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LModels.Topic", "Topic")
                        .WithMany("Schedules")
                        .HasForeignKey("TopicID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Class");

                    b.Navigation("Topic");
                });

            modelBuilder.Entity("LModels.SubjectScores", b =>
                {
                    b.HasOne("LModels.Student", null)
                        .WithMany("SubjectScores")
                        .HasForeignKey("StudentID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LModels.Topic", "Topic")
                        .WithMany("SubjectScores")
                        .HasForeignKey("TopicID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Topic");
                });

            modelBuilder.Entity("LModels.Topic", b =>
                {
                    b.HasOne("LModels.Course", "Course")
                        .WithMany("Topics")
                        .HasForeignKey("CourseID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");
                });

            modelBuilder.Entity("LModels.ExtensiveCourse.BackEndCourseDetail", b =>
                {
                    b.HasOne("LModels.Course", "Course")
                        .WithOne("BackEndCourseDetail")
                        .HasForeignKey("LModels.ExtensiveCourse.BackEndCourseDetail", "CourseID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");
                });

            modelBuilder.Entity("LModels.ExtensiveCourse.FrontEndCourseDetail", b =>
                {
                    b.HasOne("LModels.Course", "Course")
                        .WithOne("FrontEndCourseDetail")
                        .HasForeignKey("LModels.ExtensiveCourse.FrontEndCourseDetail", "CourseID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");
                });

            modelBuilder.Entity("LModels.ExtensiveCourse.FullStackCourseDetail", b =>
                {
                    b.HasOne("LModels.Course", "Course")
                        .WithOne("FullStackCourseDetail")
                        .HasForeignKey("LModels.ExtensiveCourse.FullStackCourseDetail", "CourseID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");
                });

            modelBuilder.Entity("LModels.ExtensiveCourse.GameCourseDetail", b =>
                {
                    b.HasOne("LModels.Course", "Course")
                        .WithOne("GameCourseDetail")
                        .HasForeignKey("LModels.ExtensiveCourse.GameCourseDetail", "CourseID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");
                });

            modelBuilder.Entity("LModels.Class", b =>
                {
                    b.Navigation("ExamResults");

                    b.Navigation("Schedules");
                });

            modelBuilder.Entity("LModels.Course", b =>
                {
                    b.Navigation("BackEndCourseDetail");

                    b.Navigation("FrontEndCourseDetail");

                    b.Navigation("FullStackCourseDetail");

                    b.Navigation("GameCourseDetail");

                    b.Navigation("Topics");
                });

            modelBuilder.Entity("LModels.EntranceExam", b =>
                {
                    b.Navigation("ExamResults");
                });

            modelBuilder.Entity("LModels.Student", b =>
                {
                    b.Navigation("ExamResults");

                    b.Navigation("LabSessions");

                    b.Navigation("Payments");

                    b.Navigation("SubjectScores");
                });

            modelBuilder.Entity("LModels.Teacher", b =>
                {
                    b.Navigation("Classes");

                    b.Navigation("LabSessions");
                });

            modelBuilder.Entity("LModels.Topic", b =>
                {
                    b.Navigation("Schedules");

                    b.Navigation("SubjectScores");
                });
#pragma warning restore 612, 618
        }
    }
}
