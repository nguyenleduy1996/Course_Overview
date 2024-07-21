using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Course_Overview.Migrations
{
    /// <inheritdoc />
    public partial class UpdateCourseModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CourseDetails");

            migrationBuilder.DropColumn(
                name: "CourseType",
                table: "Courses");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CourseType",
                table: "Courses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "CourseDetails",
                columns: table => new
                {
                    DetailID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourseID = table.Column<int>(type: "int", nullable: false),
                    Architecture = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Benefits = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Certification = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Curriculum = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Databases = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Demand = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DetailType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Frameworks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GameDesign = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GameDevelopmentProcess = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GameEngines = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Languages = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LearningObjectives = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProgrammingLanguages = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Salary = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TargetAudience = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Technologies = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseDetails", x => x.DetailID);
                    table.ForeignKey(
                        name: "FK_CourseDetails_Courses_CourseID",
                        column: x => x.CourseID,
                        principalTable: "Courses",
                        principalColumn: "CourseID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CourseDetails_CourseID",
                table: "CourseDetails",
                column: "CourseID");
        }
    }
}
