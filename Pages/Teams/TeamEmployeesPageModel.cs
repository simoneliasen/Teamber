using ContosoUniversity.Data;
using ContosoUniversity.Models;
using ContosoUniversity.Models.SchoolViewModels;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Linq;

namespace ContosoUniversity.Pages.Teams
{
    public class TeamEmployeesPageModel : PageModel
    {

        public List<AssignedEmployeeData> AssignedEmployeeDataList;

        public void PopulateAssignedEmployeeData(SchoolContext context,
                                               Team team)
        {
            var allEmployees = context.Employees;
            var teamEmployees = new HashSet<int>(
                team.EmpTeams.Select(c => c.EmployeeID));
            AssignedEmployeeDataList = new List<AssignedEmployeeData>();
            foreach (var employee in allEmployees)
            {
                AssignedEmployeeDataList.Add(new AssignedEmployeeData
                {
                    EmployeeID = employee.ID,
                    FullName = employee.FullName,
                    JobTitle = employee.JobTitle,
                    PersonalityType = employee.PersonalityType,
                    Assigned = teamEmployees.Contains(employee.ID)
                });
            }
        }

        public void UpdateTeamEmployees(SchoolContext context,
            string[] selectedEmployees, Team teamToUpdate)
        {
            if (selectedEmployees == null)
            {
                teamToUpdate.EmpTeams = new List<EmpTeam>();
                return;
            }

            var selectedEmployeesHS = new HashSet<string>(selectedEmployees);
            var teamEmployees = new HashSet<int>
                (teamToUpdate.EmpTeams.Select(c => c.Employee.ID));
            foreach (var employee in context.Employees)
            {
                if (selectedEmployeesHS.Contains(employee.ID.ToString()))
                {
                    if (!teamEmployees.Contains(employee.ID))
                    {
                        teamToUpdate.EmpTeams.Add(
                            new EmpTeam
                            {
                                TeamID = teamToUpdate.TeamID,
                                EmployeeID = employee.ID
                            });
                    }
                }
                else
                {
                    if (teamEmployees.Contains(employee.ID))
                    {
                        EmpTeam employeeToRemove
                            = teamToUpdate
                                .EmpTeams
                                .SingleOrDefault(i => i.EmployeeID == employee.ID);
                        context.Remove(employeeToRemove);
                    }
                }
            }
        }
    }
}
