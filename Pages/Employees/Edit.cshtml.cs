using ContosoUniversity.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;


namespace ContosoUniversity.Pages.Employees
{


    public class EditModel : EmployeeTeamsPageModel
    {
        private readonly ContosoUniversity.Data.SchoolContext _context;

        public EditModel(ContosoUniversity.Data.SchoolContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Employee Employee { get; set; }

        public string Login { get; set; }
        public string Manager { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {

            Login = HttpContext.Session.GetString("username");
            Manager = HttpContext.Session.GetString("Manager");

            if (id == null)
            {
                return NotFound();
            }

            Employee = await _context.Employees
                .Include(i => i.EmpTeams).ThenInclude(i => i.Team)
                .AsNoTracking()
                .Include(k => k.EmpQuestionnaires).ThenInclude(k => k.Questionnaire)
                .FirstOrDefaultAsync(m => m.ID == id);


            // Employee = await _context.Employees.FindAsync(id);

            if (Employee == null)
            {
                return NotFound();
            }
            PopulateAssignedTeamData(_context, Employee);
            PopulateAssignedQuestionnaireData(_context, Employee);

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id, string[] selectedTeams, string[] selectedQuestionnaires)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employeeToUpdate = await _context.Employees
                .Include(i => i.EmpTeams)
                    .ThenInclude(i => i.Team)
                .Include(k => k.EmpQuestionnaires)
                    .ThenInclude(k => k.Questionnaire)
                .FirstOrDefaultAsync(s => s.ID == id);

            if (employeeToUpdate == null)
            {
                return NotFound();
            }

            //Nedenstående var i et if statement før men det gad ikke at virke, så kører bare indholdet altid. easy
            // se i teams filen
            await TryUpdateModelAsync<Employee>(
                employeeToUpdate,
                "Employee",
                i => i.FirstMidName, i => i.LastName,
                i => i.EmpTeamDate, i => i.JobTitle,
                i => i.PersonalityType, i => i.IsManager,
                i => i.Username, i => i.Password);
            {




                UpdateEmployeeTeams(_context, selectedTeams, employeeToUpdate);
                UpdateEmployeeQuestionnaires(_context, selectedQuestionnaires, employeeToUpdate);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            //UpdateEmployeeTeams(_context, selectedTeams, employeeToUpdate);
            //UpdateEmployeeQuestionnaires(_context, selectedQuestionnaires, employeeToUpdate);
            //PopulateAssignedTeamData(_context, employeeToUpdate);
            //PopulateAssignedQuestionnaireData(_context, employeeToUpdate);
            //return Page();
        }

        /*
        public async Task<IActionResult> OnPostAsync(int id)
        {
            var employeeToUpdate = await _context.Employees.FindAsync(id);

            if (employeeToUpdate == null)
            {
                return NotFound();
            }

            if (await TryUpdateModelAsync<Employee>(
                employeeToUpdate,
                "employee",
                s => s.FirstMidName, s => s.LastName, s => s.EnrollmentDate))
            {
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }

            return Page();
        }
        */
        private bool EmployeeExists(int id)
        {
            return _context.Employees.Any(e => e.ID == id);
        }
    }
}
