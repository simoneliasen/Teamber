using ContosoUniversity.Data;
using ContosoUniversity.Models;
using ContosoUniversity.Models.SchoolViewModels;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Linq;

namespace ContosoUniversity.Pages.Employees {
    public class EmployeeTeamsPageModel : PageModel {

        public List<AssignedTeamData> AssignedTeamDataList;

        public void PopulateAssignedTeamData(SchoolContext context,
                                               Employee employee)
        {
            var allTeams = context.Teams;
            var employeeTeams = new HashSet<int>(
                employee.Enrollments.Select(c => c.TeamID));
            AssignedTeamDataList = new List<AssignedTeamData>();
            foreach (var team in allTeams)
            {
                AssignedTeamDataList.Add(new AssignedTeamData
                {
                    TeamID = team.TeamID,
                    Title = team.Title,
                    Assigned = employeeTeams.Contains(team.TeamID) 
                });
            }
        }

        public void UpdateEmployeeTeams(SchoolContext context,
            string[] selectedTeams, Employee employeeToUpdate)
        {
            if (selectedTeams == null)
            {
                employeeToUpdate.Enrollments = new List<Enrollment>();
                return;
            }

            var selectedTeamsHS = new HashSet<string>(selectedTeams);
            var employeeTeams = new HashSet<int>
                (employeeToUpdate.Enrollments.Select(c => c.Team.TeamID));
            foreach (var team in context.Teams)
            {
                if (selectedTeamsHS.Contains(team.TeamID.ToString()))
                {
                    if (!employeeTeams.Contains(team.TeamID))
                    {
                        employeeToUpdate.Enrollments.Add(
                            new Enrollment
                            {
                                EmployeeID = employeeToUpdate.ID,
                                TeamID = team.TeamID
                            });
                    }
                }
                else
                {
                    if (employeeTeams.Contains(team.TeamID))
                    {
                        Enrollment teamToRemove
                            = employeeToUpdate
                                .Enrollments
                                .SingleOrDefault(i => i.TeamID == team.TeamID);
                        context.Remove(teamToRemove);
                    }
                }
            }
        }
    }
}