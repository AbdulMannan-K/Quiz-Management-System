using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Quiz_Management_System.Migrations
{
    public partial class FinalModelv2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_courses_teachers_teacherId",
                table: "courses");

            migrationBuilder.AlterColumn<int>(
                name: "teacherId",
                table: "courses",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "CourseName",
                table: "courses",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddForeignKey(
                name: "FK_courses_teachers_teacherId",
                table: "courses",
                column: "teacherId",
                principalTable: "teachers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_courses_teachers_teacherId",
                table: "courses");

            migrationBuilder.AlterColumn<int>(
                name: "teacherId",
                table: "courses",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CourseName",
                table: "courses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_courses_teachers_teacherId",
                table: "courses",
                column: "teacherId",
                principalTable: "teachers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
