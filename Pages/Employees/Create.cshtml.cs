using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ContosoUniversity.Data;
using ContosoUniversity.Models;

namespace ContosoUniversity.Pages.Employees {
    public class CreateModel : EmployeeTeamsPageModel {
        private readonly ContosoUniversity.Data.SchoolContext _context;

        public CreateModel(ContosoUniversity.Data.SchoolContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            var employee = new Employee();
            employee.EmpTeams = new List<EmpTeam>();
            // Provides an empty collection for the foreach loop
            // foreach (var course in Model.AssignedCourseDataList)
            // in the Create Razor page.
            PopulateAssignedTeamData(_context, employee);
            return Page();
        }


        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [BindProperty]
        public Employee Employee { get; set; }


        public async Task<IActionResult> OnPostAsync(string[] selectedTeams)
        {
            var newEmployee = new Employee();
            if (selectedTeams != null)
            {
                newEmployee.EmpTeams = new List<EmpTeam>();
                foreach (var team in selectedTeams)
                {
                    var teamToAdd = new EmpTeam
                    {
                        TeamID = int.Parse(team)
                    };
                    newEmployee.EmpTeams.Add(teamToAdd);
                }
            }

            if (await TryUpdateModelAsync<Employee>(
                newEmployee,
                "Employee",
                i => i.FirstMidName, i => i.LastName,
                i => i.EmpTeamDate, i => i.JobTitle, i => i.PersonalityType))
            {

                _context.Employees.Add(newEmployee);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }

            PopulateAssignedTeamData(_context, newEmployee);
            return Page();
        }
    }
}
