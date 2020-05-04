using Microsoft.EntityFrameworkCore.Migrations;

namespace ContosoUniversity.Migrations
{
    public partial class employeeCompetences : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EmployeeCompetence",
                columns: table => new
                {
                    EmployeeCompetenceID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeID = table.Column<int>(nullable: false),
                    QuestionnaireCompetenceID = table.Column<int>(nullable: false),
                    Score = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeCompetence", x => x.EmployeeCompetenceID);
                    table.ForeignKey(
                        name: "FK_EmployeeCompetence_Employee_EmployeeID",
                        column: x => x.EmployeeID,
                        principalTable: "Employee",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeeCompetence_QuestionnaireCompetence_QuestionnaireCompetenceID",
                        column: x => x.QuestionnaireCompetenceID,
                        principalTable: "QuestionnaireCompetence",
                        principalColumn: "QuestionnaireCompetenceID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeCompetence_EmployeeID",
                table: "EmployeeCompetence",
                column: "EmployeeID");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeCompetence_QuestionnaireCompetenceID",
                table: "EmployeeCompetence",
                column: "QuestionnaireCompetenceID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmployeeCompetence");
        }
    }
}
