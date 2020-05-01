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
    }
}