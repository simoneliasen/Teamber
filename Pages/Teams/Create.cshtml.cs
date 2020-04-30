using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ContosoUniversity.Data;
using ContosoUniversity.Models;

namespace ContosoUniversity.Pages.Teams {

    public class CreateModel : TeamEmployeesPageModel
    {
        private readonly ContosoUniversity.Data.SchoolContext _context;

        public CreateModel(ContosoUniversity.Data.SchoolContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            var team = new Team();
            team.EmpTeams = new List<EmpTeam>();
            // Provides an empty collection for the foreach loop
            // foreach (var course in Model.AssignedCourseDataList)
            // in the Create Razor page.
            PopulateAssignedEmployeeData(_context, team);
            return Page();
        }


        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [BindProperty]
        public Team Team { get; set; }


        public async Task<IActionResult> OnPostAsync(string[] selectedEmployees)
        {
            var newTeam = new Team();
            if (selectedEmployees != null)
            {
                newTeam.EmpTeams = new List<EmpTeam>();
                foreach (var employee in selectedEmployees)
                {
                    var employeeToAdd = new EmpTeam
                    {
                        EmployeeID = int.Parse(employee)
                    };
                    newTeam.EmpTeams.Add(employeeToAdd);
                }
            }

            if (await TryUpdateModelAsync<Team>(
                newTeam,
                "Team",
                i => i.Title))
            {

                _context.Teams.Add(newTeam);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }

            PopulateAssignedEmployeeData(_context, newTeam);
            return Page();
        }
    }

    /*
    public class CreateModel : PageModel
    {
        private readonly ContosoUniversity.Data.SchoolContext _context;

        public CreateModel(ContosoUniversity.Data.SchoolContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Team Team { get; set; }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Teams.Add(Team);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
    */
}
