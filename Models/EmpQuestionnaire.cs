﻿namespace Teamber.Models
{


    public class EmpQuestionnaire
    {
        public int EmpQuestionnaireID { get; set; }
        public int QuestionnaireID { get; set; }
        public int EmployeeID { get; set; }
        public Questionnaire Questionnaire { get; set; }
        public Employee Employee { get; set; }
    }
}
