using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Quiz_Management_System.Migrations
{
    public partial class AddModelsToDatabasev4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "QuizMaterialid",
                table: "files",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_files_QuizMaterialid",
                table: "files",
                column: "QuizMaterialid");

            migrationBuilder.AddForeignKey(
                name: "FK_files_QuizMaterials_QuizMaterialid",
                table: "files",
                column: "QuizMaterialid",
                principalTable: "QuizMaterials",
                principalColumn: "id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_files_QuizMaterials_QuizMaterialid",
                table: "files");

            migrationBuilder.DropIndex(
                name: "IX_files_QuizMaterialid",
                table: "files");

            migrationBuilder.DropColumn(
                name: "QuizMaterialid",
                table: "files");
        }
    }
}
