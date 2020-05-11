namespace ContosoUniversity.Models
{

    public class TeamQuestionnaire
    {
        public int TeamQuestionnaireID { get; set; }
        public int QuestionnaireID { get; set; }
        public int TeamID { get; set; }

        public Questionnaire Questionnaire { get; set; }
        public Team Team { get; set; }
    }
}
