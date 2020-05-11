namespace ContosoUniversity.Models
{
    public class TeamCriteria
    {
        public int TeamCriteriaID { get; set; }
        public int TeamID { get; set; }

        public int QuestionnaireCompetenceID { get; set; }

        public Team Team { get; set; }
        public QuestionnaireCompetence QuestionnaireCompetence { get; set; }

        public int PriorityValue { get; set; }
    }
}
