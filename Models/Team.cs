using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ContosoUniversity.Models
{
    public class Team
    {

        public int TeamID { get; set; }

        [StringLength(50, MinimumLength = 3)]
        public string Title { get; set; }

        [Range(0, 101)]
        public int Synergy { get; set; } //synergy

        public ICollection<EmpTeam> EmpTeams { get; set; }
        public ICollection<TeamQuestionnaire> TeamQuestionnaires { get; set; }
        public ICollection<TeamCriteria> TeamCriterias { get; set; }
    }
}