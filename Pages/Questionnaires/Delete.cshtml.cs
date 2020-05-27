using Teamber.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Teamber {
    public class DeleteModel : PageModel {
        private readonly Teamber.Data.TeamberContext _context;

        public DeleteModel(Teamber.Data.TeamberContext context)
        {
            _context = context;
        }

        public string Login { get; set; }
        public string Manager { get; set; }

        [BindProperty]
        public Questionnaire Questionnaire { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            Login = HttpContext.Session.GetString("username");
            Manager = HttpContext.Session.GetString("Manager");

            if (id == null)
            {
                return NotFound();
            }

            Questionnaire = await _context.Questionnaires.FirstOrDefaultAsync(m => m.QuestionnaireID == id);

            if (Questionnaire == null)
            {
                return NotFound();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Questionnaire questionnaire = await _context.Questionnaires
                .Include(i => i.QuestionnaireCompetences)
               .SingleAsync(i => i.QuestionnaireID == id);

            if (Questionnaire != null)
            {
                _context.Questionnaires.Remove(questionnaire);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
