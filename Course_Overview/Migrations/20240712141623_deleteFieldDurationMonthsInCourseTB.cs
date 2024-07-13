using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Course_Overview.Migrations
{
    /// <inheritdoc />
    public partial class deleteFieldDurationMonthsInCourseTB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DurationMonths",
                table: "Courses");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DurationMonths",
                table: "Courses",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
