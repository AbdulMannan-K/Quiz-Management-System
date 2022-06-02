using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Quiz_Management_System.Migrations
{
    public partial class AddModelsToDatabasev2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "materials",
                newName: "QuizMaterials");

            migrationBuilder.AddColumn<string>(
                name: "EmailAddress",
                table: "teachers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "teachers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "EmailAddress",
                table: "students",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "students",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EmailAddress",
                table: "teachers");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "teachers");

            migrationBuilder.DropColumn(
                name: "EmailAddress",
                table: "students");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "students");

            migrationBuilder.RenameTable(
                name: "QuizMaterials",
                newName: "materials");
        }
    }
}
