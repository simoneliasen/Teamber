using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ContosoUniversity.Data;
using ContosoUniversity.Models;

namespace ContosoUniversity
{
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
        public Questionnaire Questionnaire { get; set; }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            //evt lav første array til "c#, php, php", "".
            //og så split index 0 op i flere så "c#", "php", "mysql"
            string[] selectedQuestionnaireCompetences = Questionnaire.CompetencesString.Split(", ");

            var newQuestionnaire = new Questionnaire();
            if (selectedQuestionnaireCompetences != null)
            {
                newQuestionnaire.QuestionnaireCompetences = new List<QuestionnaireCompetence>();
                foreach (var competence in selectedQuestionnaireCompetences)
                {
                    var competenceToAdd = new QuestionnaireCompetence
                    {
                        Competence = competence
                    };
                    newQuestionnaire.QuestionnaireCompetences.Add(competenceToAdd);
                }
            }

            await TryUpdateModelAsync<Questionnaire>(
                newQuestionnaire,
                "Questionnaire",
                i => i.Title, i => i.Cycle);
            {

                _context.Questionnaires.Add(newQuestionnaire);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }

            
        }
    }
}
