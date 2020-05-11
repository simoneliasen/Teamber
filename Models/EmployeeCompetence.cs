namespace ContosoUniversity.Models
{
    public class EmployeeCompetence
    {
        public int EmployeeCompetenceID { get; set; }
        public int EmployeeID { get; set; }

        public int QuestionnaireCompetenceID { get; set; }

        public Employee Employee { get; set; }
        public QuestionnaireCompetence QuestionnaireCompetence { get; set; }

        public int Score { get; set; }
    }
}
