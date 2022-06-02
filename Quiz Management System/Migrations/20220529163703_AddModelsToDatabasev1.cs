using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Quiz_Management_System.Migrations
{
    public partial class AddModelsToDatabasev1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "materials",
                columns: table => new
                {
                    description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "MCQ",
                columns: table => new
                {
                    QuestionId = table.Column<int>(type: "int", nullable: false),
                    Statement = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    marks = table.Column<int>(type: "int", nullable: false),
                    Answer = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "students",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_students", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "teachers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_teachers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "courses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourseName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    teacherId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_courses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_courses_teachers_teacherId",
                        column: x => x.teacherId,
                        principalTable: "teachers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "reports",
                columns: table => new
                {
                    ReportNumber = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IssuedById = table.Column<int>(type: "int", nullable: false),
                    IssuedToId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_reports", x => x.ReportNumber);
                    table.ForeignKey(
                        name: "FK_reports_students_IssuedById",
                        column: x => x.IssuedById,
                        principalTable: "students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_reports_teachers_IssuedToId",
                        column: x => x.IssuedToId,
                        principalTable: "teachers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CourseStudent",
                columns: table => new
                {
                    coursesId = table.Column<int>(type: "int", nullable: false),
                    studentsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseStudent", x => new { x.coursesId, x.studentsId });
                    table.ForeignKey(
                        name: "FK_CourseStudent_courses_coursesId",
                        column: x => x.coursesId,
                        principalTable: "courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CourseStudent_students_studentsId",
                        column: x => x.studentsId,
                        principalTable: "students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "quizzes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Weightage = table.Column<int>(type: "int", nullable: false),
                    CourseId = table.Column<int>(type: "int", nullable: false),
                    date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_quizzes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_quizzes_courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "questions",
                columns: table => new
                {
                    QuestionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Statement = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    marks = table.Column<int>(type: "int", nullable: false),
                    Answer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    QuizId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_questions", x => x.QuestionId);
                    table.ForeignKey(
                        name: "FK_questions_quizzes_QuizId",
                        column: x => x.QuizId,
                        principalTable: "quizzes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_courses_teacherId",
                table: "courses",
                column: "teacherId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseStudent_studentsId",
                table: "CourseStudent",
                column: "studentsId");

            migrationBuilder.CreateIndex(
                name: "IX_questions_QuizId",
                table: "questions",
                column: "QuizId");

            migrationBuilder.CreateIndex(
                name: "IX_quizzes_CourseId",
                table: "quizzes",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_reports_IssuedById",
                table: "reports",
                column: "IssuedById");

            migrationBuilder.CreateIndex(
                name: "IX_reports_IssuedToId",
                table: "reports",
                column: "IssuedToId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CourseStudent");

            migrationBuilder.DropTable(
                name: "materials");

            migrationBuilder.DropTable(
                name: "MCQ");

            migrationBuilder.DropTable(
                name: "questions");

            migrationBuilder.DropTable(
                name: "reports");

            migrationBuilder.DropTable(
                name: "quizzes");

            migrationBuilder.DropTable(
                name: "students");

            migrationBuilder.DropTable(
                name: "courses");

            migrationBuilder.DropTable(
                name: "teachers");
        }
    }
}
