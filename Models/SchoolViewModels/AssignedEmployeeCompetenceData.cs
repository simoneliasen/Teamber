namespace ContosoUniversity.Models.SchoolViewModels
{
    public class AssignedEmployeeCompetenceData
    {
        public int QuestionnaireID { get; set; }
        public int QuestionnaireCompetenceID { get; set; }
        public string Criteria { get; set; }
        public bool Assigned { get; set; }

        public int? Priority { get; set; }
    }
}
