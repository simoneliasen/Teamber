using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ContosoUniversity.Models
{
    public class Questionnaire
    {
   
        public int QuestionnaireID { get; set; }

        [StringLength(50, MinimumLength = 3)]
        public string Title { get; set; }


        public int Cycle { get; set; }

        public ICollection<EmpQuestionnaire> EmpQuestionnaires { get; set; }
        public ICollection<TeamQuestionnaire> TeamQuestionnaires { get; set; }

        public ICollection<QuestionnaireCompetence> QuestionnaireCompetences { get; set; } //så questionnaire indeholder en liste med spørgsmål fx: c#, php, mysql

        public string CompetencesString { get; set; } // skal indeholde kompetencer i en string "php, c#, javascript", der så bagefter splittes op og sættes rigtigt ind i questionairecompetences
                                                      //denne string skal bruges til .cshtml filerne, så det er en enkelt linje der bliver vist og en enkelt linje der bliver postet.
                                                      //hvis det virker skal det bare lige gøres pænt på frontend med javascript :)
                                                      //det virrrrrrkerrrrrr
    }
}