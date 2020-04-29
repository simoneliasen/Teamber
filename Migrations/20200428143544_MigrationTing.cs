using Microsoft.EntityFrameworkCore.Migrations;

namespace ContosoUniversity.Migrations
{
    public partial class MigrationTing : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EmpQuestionnaire",
                columns: table => new
                {
                    EmpQuestionnaireID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QuestionnaireID = table.Column<int>(nullable: false),
                    EmployeeID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmpQuestionnaire", x => x.EmpQuestionnaireID);
                    table.ForeignKey(
                        name: "FK_EmpQuestionnaire_Employee_EmployeeID",
                        column: x => x.EmployeeID,
                        principalTable: "Employee",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmpQuestionnaire_Questionnaire_QuestionnaireID",
                        column: x => x.QuestionnaireID,
                        principalTable: "Questionnaire",
                        principalColumn: "QuestionnaireID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EmpQuestionnaire_EmployeeID",
                table: "EmpQuestionnaire",
                column: "EmployeeID");

            migrationBuilder.CreateIndex(
                name: "IX_EmpQuestionnaire_QuestionnaireID",
                table: "EmpQuestionnaire",
                column: "QuestionnaireID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmpQuestionnaire");
        }
    }
}
