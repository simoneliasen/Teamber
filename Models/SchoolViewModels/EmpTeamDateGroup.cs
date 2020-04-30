using System;
using System.ComponentModel.DataAnnotations;

namespace ContosoUniversity.Models.SchoolViewModels
{
    public class EmpTeamDateGroup
    {
        [DataType(DataType.Date)]
        public DateTime? EmpTeamDate { get; set; }

        public int EmployeeCount { get; set; }
    }
}