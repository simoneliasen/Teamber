﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContosoUniversity.Models.SchoolViewModels {
    public class AssignedTeamData {
        public int TeamID { get; set; }
        public string Title { get; set; }
        public bool Assigned { get; set; }
    }
}
