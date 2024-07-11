using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Course_Overview.Migrations
{
    /// <inheritdoc />
    public partial class updateLabSessionTB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LabSessions_CourseDetails_CourseID",
                table: "LabSessions");

            migrationBuilder.DropForeignKey(
                name: "FK_Questions_CourseDetails_CourseDetailID",
                table: "Questions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CourseDetails",
                table: "CourseDetails");

            migrationBuilder.RenameTable(
                name: "CourseDetails",
                newName: "Courses");

            migrationBuilder.RenameColumn(
                name: "CourseDetailID",
                table: "Questions",
                newName: "CourseID");

            migrationBuilder.RenameIndex(
                name: "IX_Questions_CourseDetailID",
                table: "Questions",
                newName: "IX_Questions_CourseID");

            migrationBuilder.RenameColumn(
                name: "CourseDetailID",
                table: "Courses",
                newName: "CourseID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Courses",
                table: "Courses",
                column: "CourseID");

            migrationBuilder.AddForeignKey(
                name: "FK_LabSessions_Courses_CourseID",
                table: "LabSessions",
                column: "CourseID",
                principalTable: "Courses",
                principalColumn: "CourseID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Questions_Courses_CourseID",
                table: "Questions",
                column: "CourseID",
                principalTable: "Courses",
                principalColumn: "CourseID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LabSessions_Courses_CourseID",
                table: "LabSessions");

            migrationBuilder.DropForeignKey(
                name: "FK_Questions_Courses_CourseID",
                table: "Questions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Courses",
                table: "Courses");

            migrationBuilder.RenameTable(
                name: "Courses",
                newName: "CourseDetails");

            migrationBuilder.RenameColumn(
                name: "CourseID",
                table: "Questions",
                newName: "CourseDetailID");

            migrationBuilder.RenameIndex(
                name: "IX_Questions_CourseID",
                table: "Questions",
                newName: "IX_Questions_CourseDetailID");

            migrationBuilder.RenameColumn(
                name: "CourseID",
                table: "CourseDetails",
                newName: "CourseDetailID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CourseDetails",
                table: "CourseDetails",
                column: "CourseDetailID");

            migrationBuilder.AddForeignKey(
                name: "FK_LabSessions_CourseDetails_CourseID",
                table: "LabSessions",
                column: "CourseID",
                principalTable: "CourseDetails",
                principalColumn: "CourseDetailID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Questions_CourseDetails_CourseDetailID",
                table: "Questions",
                column: "CourseDetailID",
                principalTable: "CourseDetails",
                principalColumn: "CourseDetailID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
