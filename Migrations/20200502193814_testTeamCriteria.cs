using Microsoft.EntityFrameworkCore.Migrations;

namespace ContosoUniversity.Migrations
{
    public partial class testTeamCriteria : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                name: "IX_TeamCriteria_QuestionnaireCompetenceID",
                table: "TeamCriteria",
                column: "QuestionnaireCompetenceID");

            migrationBuilder.CreateIndex(
                name: "IX_TeamCriteria_TeamID",
                table: "TeamCriteria",
                column: "TeamID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TeamCriteria");
        }
    }
}
