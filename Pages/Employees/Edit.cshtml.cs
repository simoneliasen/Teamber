using Teamber.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Teamber.Pages.Employees
{
    public class EditModel : EmployeeTeamsPageModel
    {
        private readonly Teamber.Data.TeamberContext _context;

        public EditModel(Teamber.Data.TeamberContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Employee Employee { get; set; }

        public string Login { get; set; }
        public string Manager { get; set; }

        /// <summary>
        /// This function retrieves the nescesary data from the model so that it can be displayed on the webpage.
        /// The lambda expressions are used to include the correct data.
        /// So for example: For the employee, the related empteam object sohlud be included. And for the empteam object, the team should be included. As this data is needed.
        /// 
        /// Lastly, the two populate functions, populates a list of assigned data, that is used to check whether or not the employee is part of the teams.
        /// This is seen in the checkboxes on the page. So this list decides of the checkbox should be checked or not checked.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
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
        }
        private bool EmployeeExists(int id)
        {
            return _context.Employees.Any(e => e.ID == id);
        }
    }
}
