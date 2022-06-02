using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Quiz_Management_System.Migrations
{
    public partial class AddModelsToDatabasev5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<int>(
                name: "QuizMaterial",
                table: "files",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_files_QuizMaterial",
                table: "files",
                column: "QuizMaterial");

            migrationBuilder.AddForeignKey(
                name: "FK_files_QuizMaterials_QuizMaterial",
                table: "files",
                column: "QuizMaterial",
                principalTable: "QuizMaterials",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_files_QuizMaterials_QuizMaterial",
                table: "files");

            migrationBuilder.DropIndex(
                name: "IX_files_QuizMaterial",
                table: "files");

            migrationBuilder.DropColumn(
                name: "QuizMaterial",
                table: "files");

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
    }
}
