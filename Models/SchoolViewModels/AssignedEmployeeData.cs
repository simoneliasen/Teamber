using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContosoUniversity.Models.SchoolViewModels
{
    public class AssignedEmployeeData
    {
        public int EmployeeID { get; set; }
        public string FullName { get; set; }

        public string JobTitle { get; set; }

        public string PersonalityType { get; set; }
        public bool Assigned { get; set; }
    }
}
