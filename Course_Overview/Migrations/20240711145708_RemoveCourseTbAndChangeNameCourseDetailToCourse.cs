using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Course_Overview.Migrations
{
    /// <inheritdoc />
    public partial class RemoveCourseTbAndChangeNameCourseDetailToCourse : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CourseDetails_Courses_CourseID",
                table: "CourseDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_LabSessions_CourseDetails_CourseDetailID",
                table: "LabSessions");

            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropIndex(
                name: "IX_LabSessions_CourseDetailID",
                table: "LabSessions");

            migrationBuilder.DropIndex(
                name: "IX_CourseDetails_CourseID",
                table: "CourseDetails");

            migrationBuilder.DropColumn(
                name: "CourseDetailID",
                table: "LabSessions");

            migrationBuilder.DropColumn(
                name: "CourseID",
                table: "CourseDetails");

            migrationBuilder.CreateIndex(
                name: "IX_LabSessions_CourseID",
                table: "LabSessions",
                column: "CourseID");

            migrationBuilder.AddForeignKey(
                name: "FK_LabSessions_CourseDetails_CourseID",
                table: "LabSessions",
                column: "CourseID",
                principalTable: "CourseDetails",
                principalColumn: "CourseDetailID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LabSessions_CourseDetails_CourseID",
                table: "LabSessions");

            migrationBuilder.DropIndex(
                name: "IX_LabSessions_CourseID",
                table: "LabSessions");

            migrationBuilder.AddColumn<int>(
                name: "CourseDetailID",
                table: "LabSessions",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CourseID",
                table: "CourseDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    CourseID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourseName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.CourseID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LabSessions_CourseDetailID",
                table: "LabSessions",
                column: "CourseDetailID");

            migrationBuilder.CreateIndex(
                name: "IX_CourseDetails_CourseID",
                table: "CourseDetails",
                column: "CourseID");

            migrationBuilder.AddForeignKey(
                name: "FK_CourseDetails_Courses_CourseID",
                table: "CourseDetails",
                column: "CourseID",
                principalTable: "Courses",
                principalColumn: "CourseID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LabSessions_CourseDetails_CourseDetailID",
                table: "LabSessions",
                column: "CourseDetailID",
                principalTable: "CourseDetails",
                principalColumn: "CourseDetailID");
        }
    }
}
