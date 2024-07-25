using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Course_Overview.Migrations
{
    /// <inheritdoc />
    public partial class AddFieldInUserTB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsNewUser",
                table: "Users",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsNewUser",
                table: "Users");
        }
    }
}
