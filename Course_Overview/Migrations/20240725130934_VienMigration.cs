using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Course_Overview.Migrations
{
    /// <inheritdoc />
    public partial class VienMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ClassStudents",
                columns: table => new
                {
                    ClassID = table.Column<int>(type: "int", nullable: false),
                    StudentID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClassStudents", x => new { x.ClassID, x.StudentID });
                    table.ForeignKey(
                        name: "FK_ClassStudents_Classes_ClassID",
                        column: x => x.ClassID,
                        principalTable: "Classes",
                        principalColumn: "ClassID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClassStudents_Students_StudentID",
                        column: x => x.StudentID,
                        principalTable: "Students",
                        principalColumn: "StudentID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EX_StudentExamResults",
                columns: table => new
                {
                    StudentID = table.Column<int>(type: "int", nullable: false),
                    ExamID = table.Column<int>(type: "int", nullable: false),
                    QuestionID = table.Column<int>(type: "int", nullable: false),
                    StudentAnswers = table.Column<int>(type: "int", nullable: false),
                    IsCorrect = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EX_StudentExamResults", x => new { x.StudentID, x.ExamID, x.QuestionID });
                });

            migrationBuilder.CreateTable(
                name: "EX_Subjects",
                columns: table => new
                {
                    SubjectID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SubjectName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EX_Subjects", x => x.SubjectID);
                });

            migrationBuilder.CreateTable(
                name: "EX_Exams",
                columns: table => new
                {
                    ExamID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExamName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    ExamDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SubjectID = table.Column<int>(type: "int", nullable: false),
                    TotalMins = table.Column<int>(type: "int", nullable: false),
                    TimeEnd = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EX_Exams", x => x.ExamID);
                    table.ForeignKey(
                        name: "FK_EX_Exams_EX_Subjects_SubjectID",
                        column: x => x.SubjectID,
                        principalTable: "EX_Subjects",
                        principalColumn: "SubjectID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EX_Lessons",
                columns: table => new
                {
                    LessonID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LessonName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    SubjectID = table.Column<int>(type: "int", nullable: false),
                    LessonNumber = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EX_Lessons", x => x.LessonID);
                    table.ForeignKey(
                        name: "FK_EX_Lessons_EX_Subjects_SubjectID",
                        column: x => x.SubjectID,
                        principalTable: "EX_Subjects",
                        principalColumn: "SubjectID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ClassExams",
                columns: table => new
                {
                    ClassID = table.Column<int>(type: "int", nullable: false),
                    ExamID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClassExams", x => new { x.ClassID, x.ExamID });
                    table.ForeignKey(
                        name: "FK_ClassExams_Classes_ClassID",
                        column: x => x.ClassID,
                        principalTable: "Classes",
                        principalColumn: "ClassID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClassExams_EX_Exams_ExamID",
                        column: x => x.ExamID,
                        principalTable: "EX_Exams",
                        principalColumn: "ExamID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EX_Questions",
                columns: table => new
                {
                    QuestionID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QuestionText = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LessonID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EX_Questions", x => x.QuestionID);
                    table.ForeignKey(
                        name: "FK_EX_Questions_EX_Lessons_LessonID",
                        column: x => x.LessonID,
                        principalTable: "EX_Lessons",
                        principalColumn: "LessonID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EX_Answers",
                columns: table => new
                {
                    AnswerID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AnswerText = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsCorrect = table.Column<bool>(type: "bit", nullable: false),
                    QuestionID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EX_Answers", x => x.AnswerID);
                    table.ForeignKey(
                        name: "FK_EX_Answers_EX_Questions_QuestionID",
                        column: x => x.QuestionID,
                        principalTable: "EX_Questions",
                        principalColumn: "QuestionID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EX_ExamQuestions",
                columns: table => new
                {
                    ExamID = table.Column<int>(type: "int", nullable: false),
                    QuestionID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EX_ExamQuestions", x => new { x.ExamID, x.QuestionID });
                    table.ForeignKey(
                        name: "FK_EX_ExamQuestions_EX_Exams_ExamID",
                        column: x => x.ExamID,
                        principalTable: "EX_Exams",
                        principalColumn: "ExamID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EX_ExamQuestions_EX_Questions_QuestionID",
                        column: x => x.QuestionID,
                        principalTable: "EX_Questions",
                        principalColumn: "QuestionID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ClassExams_ExamID",
                table: "ClassExams",
                column: "ExamID");

            migrationBuilder.CreateIndex(
                name: "IX_ClassStudents_StudentID",
                table: "ClassStudents",
                column: "StudentID");

            migrationBuilder.CreateIndex(
                name: "IX_EX_Answers_QuestionID",
                table: "EX_Answers",
                column: "QuestionID");

            migrationBuilder.CreateIndex(
                name: "IX_EX_ExamQuestions_QuestionID",
                table: "EX_ExamQuestions",
                column: "QuestionID");

            migrationBuilder.CreateIndex(
                name: "IX_EX_Exams_SubjectID",
                table: "EX_Exams",
                column: "SubjectID");

            migrationBuilder.CreateIndex(
                name: "IX_EX_Lessons_SubjectID",
                table: "EX_Lessons",
                column: "SubjectID");

            migrationBuilder.CreateIndex(
                name: "IX_EX_Questions_LessonID",
                table: "EX_Questions",
                column: "LessonID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClassExams");

            migrationBuilder.DropTable(
                name: "ClassStudents");

            migrationBuilder.DropTable(
                name: "EX_Answers");

            migrationBuilder.DropTable(
                name: "EX_ExamQuestions");

            migrationBuilder.DropTable(
                name: "EX_StudentExamResults");

            migrationBuilder.DropTable(
                name: "EX_Exams");

            migrationBuilder.DropTable(
                name: "EX_Questions");

            migrationBuilder.DropTable(
                name: "EX_Lessons");

            migrationBuilder.DropTable(
                name: "EX_Subjects");
        }
    }
}
