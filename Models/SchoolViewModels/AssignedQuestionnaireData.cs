﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContosoUniversity.Models.SchoolViewModels
{
    public class AssignedQuestionnaireData
    {
        public int QuestionnaireID { get; set; }
        public string Title { get; set; }
        public bool Assigned { get; set; }
    }
}
