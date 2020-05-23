using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ContosoUniversity.Migrations
{
    public partial class TeamberMigrationFull : Migration
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
                    Cycle = table.Column<int>(nullable: false),
                    CompetencesString = table.Column<string>(nullable: true)
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
                name: "QuestionnaireCompetence",
                columns: table => new
                {
                    QuestionnaireCompetenceID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QuestionnaireID = table.Column<int>(nullable: false),
                    Competence = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuestionnaireCompetence", x => x.QuestionnaireCompetenceID);
                    table.ForeignKey(
                        name: "FK_QuestionnaireCompetence_Questionnaire_QuestionnaireID",
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
                    EmployeeID = table.Column<int>(nullable: false),
                    questionnaireRole = table.Column<string>(nullable: true)
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

            migrationBuilder.CreateTable(
                name: "TeamCriteria",
                columns: table => new
                {
                    TeamCriteriaID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TeamID = table.Column<int>(nullable: false),
                    QuestionnaireCompetenceID = table.Column<int>(nullable: false),
                    PriorityValue = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeamCriteria", x => x.TeamCriteriaID);
                    table.ForeignKey(
                        name: "FK_TeamCriteria_QuestionnaireCompetence_QuestionnaireCompetenceID",
                        column: x => x.QuestionnaireCompetenceID,
                        principalTable: "QuestionnaireCompetence",
                        principalColumn: "QuestionnaireCompetenceID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TeamCriteria_Team_TeamID",
                        column: x => x.TeamID,
                        principalTable: "Team",
                        principalColumn: "TeamID",
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
                name: "IX_QuestionnaireCompetence_QuestionnaireID",
                table: "QuestionnaireCompetence",
                column: "QuestionnaireID");

            migrationBuilder.CreateIndex(
                name: "IX_TeamCriteria_QuestionnaireCompetenceID",
                table: "TeamCriteria",
                column: "QuestionnaireCompetenceID");

            migrationBuilder.CreateIndex(
                name: "IX_TeamCriteria_TeamID",
                table: "TeamCriteria",
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
                name: "EmployeeCompetence");

            migrationBuilder.DropTable(
                name: "EmpQuestionnaire");

            migrationBuilder.DropTable(
                name: "EmpTeam");

            migrationBuilder.DropTable(
                name: "TeamCriteria");

            migrationBuilder.DropTable(
                name: "TeamQuestionnaire");

            migrationBuilder.DropTable(
                name: "Employee");

            migrationBuilder.DropTable(
                name: "QuestionnaireCompetence");

            migrationBuilder.DropTable(
                name: "Team");

            migrationBuilder.DropTable(
                name: "Questionnaire");
        }
    }
}
