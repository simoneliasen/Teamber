using Teamber.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Teamber.Pages.Teams
{

    public class EditModel : TeamEmployeesPageModel
    {
        private readonly Teamber.Data.TeamberContext _context;

        public EditModel(Teamber.Data.TeamberContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Team Team { get; set; }

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

            Team = await _context.Teams
                .Include(i => i.EmpTeams).ThenInclude(i => i.Employee).
                Include(k => k.TeamQuestionnaires).ThenInclude(k => k.Questionnaire)
                .Include(k => k.TeamCriterias)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.TeamID == id);

            if (Team == null)
            {
                return NotFound();
            }
            PopulateAssignedEmployeeData(_context, Team);
            PopulateAssignedQuestionnaireData(_context, Team);
            PopulateAllCompetencesData(_context, Team);
            PopulateAllEmpCompetencesString(_context);
            PopulateAllEmpQuestionnairesString(_context);
            PopulateAllQuestionnairesStringForEdit(_context, Team);
            PopulateAllQuestionnaireTitlesString(_context);
            PopulateTeamMembers(Team);

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id, string[] selectedEmployees, string[] selectedQuestionnaires, int[] selectedCompetences, int[] selectedCompetencesValue)
        {
            if (id == null)
            {
                return NotFound();
            }

            var teamToUpdate = await _context.Teams
                .Include(i => i.EmpTeams)
                .ThenInclude(i => i.Employee)
                .Include(k => k.TeamQuestionnaires).ThenInclude(k => k.Questionnaire)
                .Include(i => i.TeamCriterias)
                .FirstOrDefaultAsync(s => s.TeamID == id);



            if (teamToUpdate == null)
            {
                return NotFound();
            }

            await TryUpdateModelAsync<Team>(
                teamToUpdate,
                "Team",
                i => i.Title, i => i.Synergy);
            {

                UpdateTeamEmployees(_context, selectedEmployees, teamToUpdate);
                UpdateTeamQuestionnaires(_context, selectedQuestionnaires, teamToUpdate);
                UpdateTeamCriterias(_context, selectedCompetences, selectedCompetencesValue, teamToUpdate);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
        }
        private bool TeamExists(int id)
        {
            return _context.Teams.Any(e => e.TeamID == id);
        }
    }
}
