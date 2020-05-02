using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContosoUniversity.Models
{
    public class QuestionnaireCompetence
    {
        public int QuestionnaireCompetenceID { get; set; }
        public int QuestionnaireID { get; set; }
        public string Competence { get; set; }
        public Questionnaire Questionnaire { get; set; }
    }
}
