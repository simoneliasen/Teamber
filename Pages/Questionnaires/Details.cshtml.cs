using Teamber.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;


namespace Teamber
{
    public class DetailsModel : PageModel
    {
        private readonly Teamber.Data.TeamberContext _context;

        public DetailsModel(Teamber.Data.TeamberContext context)
        {
            _context = context;
        }

        public string Login { get; set; }
        public string Manager { get; set; }

        public Questionnaire Questionnaire { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            Login = HttpContext.Session.GetString("username");
            Manager = HttpContext.Session.GetString("Manager");

            if (id == null)
            {
                return NotFound();
            }

            Questionnaire = await _context.Questionnaires.Include(s => s.QuestionnaireCompetences)
                .FirstOrDefaultAsync(m => m.QuestionnaireID == id);

            if (Questionnaire == null)
            {
                return NotFound();
            }
            return Page();

        }
    }
}
