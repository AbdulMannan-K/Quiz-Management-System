using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Quiz_Management_System.Migrations
{
    public partial class FinalModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Choice_questions_QuestionId",
                table: "Choice");

            migrationBuilder.DropForeignKey(
                name: "FK_Link_QuizMaterials_QuizMaterialId",
                table: "Link");

            migrationBuilder.DropForeignKey(
                name: "FK_questions_quizzes_QuizId",
                table: "questions");

            migrationBuilder.DropForeignKey(
                name: "FK_quizzes_courses_CourseId",
                table: "quizzes");

            migrationBuilder.DropForeignKey(
                name: "FK_reports_students_IssuedById",
                table: "reports");

            migrationBuilder.DropForeignKey(
                name: "FK_reports_teachers_IssuedToId",
                table: "reports");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Link",
                table: "Link");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Choice",
                table: "Choice");

            migrationBuilder.RenameTable(
                name: "Link",
                newName: "links");

            migrationBuilder.RenameTable(
                name: "Choice",
                newName: "choices");

            migrationBuilder.RenameColumn(
                name: "IssuedToId",
                table: "reports",
                newName: "teacherId");

            migrationBuilder.RenameColumn(
                name: "IssuedById",
                table: "reports",
                newName: "studentId");

            migrationBuilder.RenameIndex(
                name: "IX_reports_IssuedToId",
                table: "reports",
                newName: "IX_reports_teacherId");

            migrationBuilder.RenameIndex(
                name: "IX_reports_IssuedById",
                table: "reports",
                newName: "IX_reports_studentId");

            migrationBuilder.RenameColumn(
                name: "CourseId",
                table: "quizzes",
                newName: "courseId");

            migrationBuilder.RenameIndex(
                name: "IX_quizzes_CourseId",
                table: "quizzes",
                newName: "IX_quizzes_courseId");

            migrationBuilder.RenameColumn(
                name: "QuizId",
                table: "questions",
                newName: "quizId");

            migrationBuilder.RenameIndex(
                name: "IX_questions_QuizId",
                table: "questions",
                newName: "IX_questions_quizId");

            migrationBuilder.RenameColumn(
                name: "QuizMaterialId",
                table: "links",
                newName: "quizMaterialId");

            migrationBuilder.RenameIndex(
                name: "IX_Link_QuizMaterialId",
                table: "links",
                newName: "IX_links_quizMaterialId");

            migrationBuilder.RenameColumn(
                name: "QuestionId",
                table: "choices",
                newName: "questionId");

            migrationBuilder.RenameIndex(
                name: "IX_Choice_QuestionId",
                table: "choices",
                newName: "IX_choices_questionId");

            migrationBuilder.AddColumn<int>(
                name: "quizMaterialId",
                table: "quizzes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "quizId",
                table: "questions",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "quizMaterialId",
                table: "links",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "questionId",
                table: "choices",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_links",
                table: "links",
                column: "link");

            migrationBuilder.AddPrimaryKey(
                name: "PK_choices",
                table: "choices",
                column: "choice");

            migrationBuilder.CreateTable(
                name: "courseStudents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentId = table.Column<int>(type: "int", nullable: false),
                    CourseId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_courseStudents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_courseStudents_courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_courseStudents_students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_courseStudents_CourseId",
                table: "courseStudents",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_courseStudents_StudentId",
                table: "courseStudents",
                column: "StudentId");

            migrationBuilder.AddForeignKey(
                name: "FK_choices_questions_questionId",
                table: "choices",
                column: "questionId",
                principalTable: "questions",
                principalColumn: "QuestionId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_links_QuizMaterials_quizMaterialId",
                table: "links",
                column: "quizMaterialId",
                principalTable: "QuizMaterials",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_questions_quizzes_quizId",
                table: "questions",
                column: "quizId",
                principalTable: "quizzes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_quizzes_courses_courseId",
                table: "quizzes",
                column: "courseId",
                principalTable: "courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_reports_students_studentId",
                table: "reports",
                column: "studentId",
                principalTable: "students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_reports_teachers_teacherId",
                table: "reports",
                column: "teacherId",
                principalTable: "teachers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_choices_questions_questionId",
                table: "choices");

            migrationBuilder.DropForeignKey(
                name: "FK_links_QuizMaterials_quizMaterialId",
                table: "links");

            migrationBuilder.DropForeignKey(
                name: "FK_questions_quizzes_quizId",
                table: "questions");

            migrationBuilder.DropForeignKey(
                name: "FK_quizzes_courses_courseId",
                table: "quizzes");

            migrationBuilder.DropForeignKey(
                name: "FK_reports_students_studentId",
                table: "reports");

            migrationBuilder.DropForeignKey(
                name: "FK_reports_teachers_teacherId",
                table: "reports");

            migrationBuilder.DropTable(
                name: "courseStudents");

            migrationBuilder.DropPrimaryKey(
                name: "PK_links",
                table: "links");

            migrationBuilder.DropPrimaryKey(
                name: "PK_choices",
                table: "choices");

            migrationBuilder.DropColumn(
                name: "quizMaterialId",
                table: "quizzes");

            migrationBuilder.RenameTable(
                name: "links",
                newName: "Link");

            migrationBuilder.RenameTable(
                name: "choices",
                newName: "Choice");

            migrationBuilder.RenameColumn(
                name: "teacherId",
                table: "reports",
                newName: "IssuedToId");

            migrationBuilder.RenameColumn(
                name: "studentId",
                table: "reports",
                newName: "IssuedById");

            migrationBuilder.RenameIndex(
                name: "IX_reports_teacherId",
                table: "reports",
                newName: "IX_reports_IssuedToId");

            migrationBuilder.RenameIndex(
                name: "IX_reports_studentId",
                table: "reports",
                newName: "IX_reports_IssuedById");

            migrationBuilder.RenameColumn(
                name: "courseId",
                table: "quizzes",
                newName: "CourseId");

            migrationBuilder.RenameIndex(
                name: "IX_quizzes_courseId",
                table: "quizzes",
                newName: "IX_quizzes_CourseId");

            migrationBuilder.RenameColumn(
                name: "quizId",
                table: "questions",
                newName: "QuizId");

            migrationBuilder.RenameIndex(
                name: "IX_questions_quizId",
                table: "questions",
                newName: "IX_questions_QuizId");

            migrationBuilder.RenameColumn(
                name: "quizMaterialId",
                table: "Link",
                newName: "QuizMaterialId");

            migrationBuilder.RenameIndex(
                name: "IX_links_quizMaterialId",
                table: "Link",
                newName: "IX_Link_QuizMaterialId");

            migrationBuilder.RenameColumn(
                name: "questionId",
                table: "Choice",
                newName: "QuestionId");

            migrationBuilder.RenameIndex(
                name: "IX_choices_questionId",
                table: "Choice",
                newName: "IX_Choice_QuestionId");

            migrationBuilder.AlterColumn<int>(
                name: "QuizId",
                table: "questions",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "QuizMaterialId",
                table: "Link",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "QuestionId",
                table: "Choice",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Link",
                table: "Link",
                column: "link");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Choice",
                table: "Choice",
                column: "choice");

            migrationBuilder.AddForeignKey(
                name: "FK_Choice_questions_QuestionId",
                table: "Choice",
                column: "QuestionId",
                principalTable: "questions",
                principalColumn: "QuestionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Link_QuizMaterials_QuizMaterialId",
                table: "Link",
                column: "QuizMaterialId",
                principalTable: "QuizMaterials",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_questions_quizzes_QuizId",
                table: "questions",
                column: "QuizId",
                principalTable: "quizzes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_quizzes_courses_CourseId",
                table: "quizzes",
                column: "CourseId",
                principalTable: "courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_reports_students_IssuedById",
                table: "reports",
                column: "IssuedById",
                principalTable: "students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_reports_teachers_IssuedToId",
                table: "reports",
                column: "IssuedToId",
                principalTable: "teachers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
