namespace ContosoUniversity.Models.SchoolViewModels
{
    public class AssignedQuestionnaireCompetenceData
    {
        public int QuestionnaireID { get; set; }
        public string Competence { get; set; }
        public bool Assigned { get; set; }

        public int QuestionnaireCompetenceID { get; set; }
    }
}
