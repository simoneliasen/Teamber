using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ContosoUniversity.Models
{
    public enum Grade
    {
        A, B, C, D, F
    }

    public class EmpTeam
    {
        public int EmpTeamID { get; set; }
        public int TeamID { get; set; }
        public int EmployeeID { get; set; }

        public Team Team { get; set; }
        public Employee Employee { get; set; }
    }
}
