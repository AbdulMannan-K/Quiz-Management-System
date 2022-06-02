using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Quiz_Management_System.Migrations
{
    public partial class AddAllModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_quizzes_QuizMaterials_Materialid",
                table: "quizzes");

            migrationBuilder.DropTable(
                name: "files");

            migrationBuilder.DropTable(
                name: "MCQ");

            migrationBuilder.RenameColumn(
                name: "Materialid",
                table: "quizzes",
                newName: "QuizMaterial");

            migrationBuilder.RenameIndex(
                name: "IX_quizzes_Materialid",
                table: "quizzes",
                newName: "IX_quizzes_QuizMaterial");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "QuizMaterials",
                newName: "Id");

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "teachers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "students",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "isMCQ",
                table: "questions",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "Choice",
                columns: table => new
                {
                    choice = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    QuestionId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Choice", x => x.choice);
                    table.ForeignKey(
                        name: "FK_Choice_questions_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "questions",
                        principalColumn: "QuestionId");
                });

            migrationBuilder.CreateTable(
                name: "Link",
                columns: table => new
                {
                    link = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    QuizMaterialId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Link", x => x.link);
                    table.ForeignKey(
                        name: "FK_Link_QuizMaterials_QuizMaterialId",
                        column: x => x.QuizMaterialId,
                        principalTable: "QuizMaterials",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Choice_QuestionId",
                table: "Choice",
                column: "QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_Link_QuizMaterialId",
                table: "Link",
                column: "QuizMaterialId");

            migrationBuilder.AddForeignKey(
                name: "FK_quizzes_QuizMaterials_QuizMaterial",
                table: "quizzes",
                column: "QuizMaterial",
                principalTable: "QuizMaterials",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_quizzes_QuizMaterials_QuizMaterial",
                table: "quizzes");

            migrationBuilder.DropTable(
                name: "Choice");

            migrationBuilder.DropTable(
                name: "Link");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "teachers");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "students");

            migrationBuilder.DropColumn(
                name: "isMCQ",
                table: "questions");

            migrationBuilder.RenameColumn(
                name: "QuizMaterial",
                table: "quizzes",
                newName: "Materialid");

            migrationBuilder.RenameIndex(
                name: "IX_quizzes_QuizMaterial",
                table: "quizzes",
                newName: "IX_quizzes_Materialid");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "QuizMaterials",
                newName: "id");

            migrationBuilder.CreateTable(
                name: "files",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QuizMaterial = table.Column<int>(type: "int", nullable: false),
                    files = table.Column<byte[]>(type: "varbinary(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_files", x => x.Id);
                    table.ForeignKey(
                        name: "FK_files_QuizMaterials_QuizMaterial",
                        column: x => x.QuizMaterial,
                        principalTable: "QuizMaterials",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MCQ",
                columns: table => new
                {
                    Answer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    QuestionId = table.Column<int>(type: "int", nullable: false),
                    Statement = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    marks = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateIndex(
                name: "IX_files_QuizMaterial",
                table: "files",
                column: "QuizMaterial");

            migrationBuilder.AddForeignKey(
                name: "FK_quizzes_QuizMaterials_Materialid",
                table: "quizzes",
                column: "Materialid",
                principalTable: "QuizMaterials",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
