using ContosoUniversity.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace ContosoUniversity.Pages.Teams
{
    public class DetailsModel : TeamEmployeesPageModel
    {
        private readonly ContosoUniversity.Data.SchoolContext _context;

        public DetailsModel(ContosoUniversity.Data.SchoolContext context)
        {
            _context = context;
        }

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
       .Include(s => s.EmpTeams)
       .ThenInclude(e => e.Employee)
       .Include(x => x.TeamQuestionnaires)
       .ThenInclude(o => o.Questionnaire)
       .Include(k => k.TeamCriterias)
       .AsNoTracking()
       .FirstOrDefaultAsync(m => m.TeamID == id);
            PopulateAssignedTeamCriteriaData(_context, Team);

            if (Team == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
