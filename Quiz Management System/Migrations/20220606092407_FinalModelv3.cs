using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Quiz_Management_System.Migrations
{
    public partial class FinalModelv3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_links",
                table: "links");

            migrationBuilder.DropPrimaryKey(
                name: "PK_choices",
                table: "choices");

            migrationBuilder.DropColumn(
                name: "Weightage",
                table: "quizzes");

            migrationBuilder.AlterColumn<string>(
                name: "link",
                table: "links",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "links",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<string>(
                name: "choice",
                table: "choices",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "choices",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_links",
                table: "links",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_choices",
                table: "choices",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_links",
                table: "links");

            migrationBuilder.DropPrimaryKey(
                name: "PK_choices",
                table: "choices");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "links");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "choices");

            migrationBuilder.AddColumn<int>(
                name: "Weightage",
                table: "quizzes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "link",
                table: "links",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "choice",
                table: "choices",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_links",
                table: "links",
                column: "link");

            migrationBuilder.AddPrimaryKey(
                name: "PK_choices",
                table: "choices",
                column: "choice");
        }
    }
}
