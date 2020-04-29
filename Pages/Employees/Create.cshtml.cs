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
            employee.Enrollments = new List<Enrollment>();
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
                newEmployee.Enrollments = new List<Enrollment>();
                foreach (var team in selectedTeams)
                {
                    var teamToAdd = new Enrollment
                    {
                        TeamID = int.Parse(team)
                    };
                    newEmployee.Enrollments.Add(teamToAdd);
                }
            }

            if (await TryUpdateModelAsync<Employee>(
                newEmployee,
                "Employee",
                i => i.FirstMidName, i => i.LastName,
                i => i.EnrollmentDate))
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
