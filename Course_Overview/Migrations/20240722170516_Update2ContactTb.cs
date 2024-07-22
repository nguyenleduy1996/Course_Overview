using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Course_Overview.Migrations
{
    /// <inheritdoc />
    public partial class Update2ContactTb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Contacts_Phone1",
                table: "Contacts");

            migrationBuilder.DropIndex(
                name: "IX_Contacts_Phone2",
                table: "Contacts");

            migrationBuilder.AlterColumn<string>(
                name: "Phone2",
                table: "Contacts",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "Phone1",
                table: "Contacts",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "Map",
                table: "Contacts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Contacts_Phone1",
                table: "Contacts",
                column: "Phone1",
                unique: true,
                filter: "[Phone1] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Contacts_Phone2",
                table: "Contacts",
                column: "Phone2",
                unique: true,
                filter: "[Phone2] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Contacts_Phone1",
                table: "Contacts");

            migrationBuilder.DropIndex(
                name: "IX_Contacts_Phone2",
                table: "Contacts");

            migrationBuilder.DropColumn(
                name: "Map",
                table: "Contacts");

            migrationBuilder.AlterColumn<string>(
                name: "Phone2",
                table: "Contacts",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Phone1",
                table: "Contacts",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Contacts_Phone1",
                table: "Contacts",
                column: "Phone1",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Contacts_Phone2",
                table: "Contacts",
                column: "Phone2",
                unique: true);
        }
    }
}
