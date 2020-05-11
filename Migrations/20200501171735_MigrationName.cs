using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace ContosoUniversity.Migrations
{
    public partial class MigrationName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LastName = table.Column<string>(maxLength: 50, nullable: false),
                    FirstName = table.Column<string>(maxLength: 50, nullable: false),
                    EmpTeamDate = table.Column<DateTime>(nullable: false),
                    JobTitle = table.Column<string>(nullable: false),
                    PersonalityType = table.Column<string>(nullable: true),
                    IsManager = table.Column<bool>(nullable: false),
                    Username = table.Column<string>(nullable: false),
                    Password = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Questionnaire",
                columns: table => new
                {
                    QuestionnaireID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(maxLength: 50, nullable: true),
                    Cycle = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Questionnaire", x => x.QuestionnaireID);
                });

            migrationBuilder.CreateTable(
                name: "Team",
                columns: table => new
                {
                    TeamID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(maxLength: 50, nullable: true),
                    Synergy = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Team", x => x.TeamID);
                });

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

            migrationBuilder.CreateTable(
                name: "EmpTeam",
                columns: table => new
                {
                    EmpTeamID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TeamID = table.Column<int>(nullable: false),
                    EmployeeID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmpTeam", x => x.EmpTeamID);
                    table.ForeignKey(
                        name: "FK_EmpTeam_Employee_EmployeeID",
                        column: x => x.EmployeeID,
                        principalTable: "Employee",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmpTeam_Team_TeamID",
                        column: x => x.TeamID,
                        principalTable: "Team",
                        principalColumn: "TeamID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TeamQuestionnaire",
                columns: table => new
                {
                    TeamQuestionnaireID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QuestionnaireID = table.Column<int>(nullable: false),
                    TeamID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeamQuestionnaire", x => x.TeamQuestionnaireID);
                    table.ForeignKey(
                        name: "FK_TeamQuestionnaire_Questionnaire_QuestionnaireID",
                        column: x => x.QuestionnaireID,
                        principalTable: "Questionnaire",
                        principalColumn: "QuestionnaireID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TeamQuestionnaire_Team_TeamID",
                        column: x => x.TeamID,
                        principalTable: "Team",
                        principalColumn: "TeamID",
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

            migrationBuilder.CreateIndex(
                name: "IX_EmpTeam_EmployeeID",
                table: "EmpTeam",
                column: "EmployeeID");

            migrationBuilder.CreateIndex(
                name: "IX_EmpTeam_TeamID",
                table: "EmpTeam",
                column: "TeamID");

            migrationBuilder.CreateIndex(
                name: "IX_TeamQuestionnaire_QuestionnaireID",
                table: "TeamQuestionnaire",
                column: "QuestionnaireID");

            migrationBuilder.CreateIndex(
                name: "IX_TeamQuestionnaire_TeamID",
                table: "TeamQuestionnaire",
                column: "TeamID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmpQuestionnaire");

            migrationBuilder.DropTable(
                name: "EmpTeam");

            migrationBuilder.DropTable(
                name: "TeamQuestionnaire");

            migrationBuilder.DropTable(
                name: "Employee");

            migrationBuilder.DropTable(
                name: "Questionnaire");

            migrationBuilder.DropTable(
                name: "Team");
        }
    }
}
