﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContosoUniversity.Models.SchoolViewModels
{
    public class AssignedQuestionnaireCompetenceData
    {
        public int QuestionnaireID { get; set; }
        public string Competence { get; set; }
        public bool Assigned { get; set; }
    }
}
