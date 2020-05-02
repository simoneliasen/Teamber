using Microsoft.EntityFrameworkCore.Migrations;

namespace ContosoUniversity.Migrations
{
    public partial class competencestring : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CompetencesString",
                table: "Questionnaire",
                nullable: true);

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

            migrationBuilder.CreateIndex(
                name: "IX_QuestionnaireCompetence_QuestionnaireID",
                table: "QuestionnaireCompetence",
                column: "QuestionnaireID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "QuestionnaireCompetence");

            migrationBuilder.DropColumn(
                name: "CompetencesString",
                table: "Questionnaire");
        }
    }
}
