    using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Quiz_Management_System.Migrations
{
    public partial class AddModelsToDatabasev3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Materialid",
                table: "quizzes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "id",
                table: "QuizMaterials",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_QuizMaterials",
                table: "QuizMaterials",
                column: "id");

            migrationBuilder.CreateTable(
                name: "files",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    files = table.Column<byte[]>(type: "varbinary(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_files", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_quizzes_Materialid",
                table: "quizzes",
                column: "Materialid");

            migrationBuilder.AddForeignKey(
                name: "FK_quizzes_QuizMaterials_Materialid",
                table: "quizzes",
                column: "Materialid",
                principalTable: "QuizMaterials",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_quizzes_QuizMaterials_Materialid",
                table: "quizzes");

            migrationBuilder.DropTable(
                name: "files");

            migrationBuilder.DropIndex(
                name: "IX_quizzes_Materialid",
                table: "quizzes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_QuizMaterials",
                table: "QuizMaterials");

            migrationBuilder.DropColumn(
                name: "Materialid",
                table: "quizzes");

            migrationBuilder.DropColumn(
                name: "id",
                table: "QuizMaterials");
        }
    }
}
