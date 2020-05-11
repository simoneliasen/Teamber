using ContosoUniversity.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContosoUniversity.Pages.Questionnaires
{
    public class EditModel : QuestionnaireCompetencesPageModel
    {
        private readonly ContosoUniversity.Data.SchoolContext _context;

        public EditModel(ContosoUniversity.Data.SchoolContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Questionnaire Questionnaire { get; set; }

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

            Questionnaire = await _context.Questionnaires.Include(s => s.QuestionnaireCompetences)
                .FirstOrDefaultAsync(m => m.QuestionnaireID == id);

            if (Questionnaire == null)
            {
                return NotFound();
            }

            PopulateAssignedQuestionnaireCompetenceData(_context, Questionnaire);

            return Page();
        }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int? id, string[] selectedQuestionnaireCompetences)
        {
            string[] extraCompetences;
            if (Questionnaire.CompetencesString != null)
            {
                extraCompetences = Questionnaire.CompetencesString.Split(", ");
            }
            else
            {
                extraCompetences = null;
            }
            //den her indeholder de competencer man gerne vil tilføje extra til spørgeskemaet. Altså den kommaseparerede textbox.




            if (id == null)
            {
                return NotFound();
            }

            var questionnaireToUpdate = await _context.Questionnaires
                .Include(i => i.QuestionnaireCompetences)
                .FirstOrDefaultAsync(s => s.QuestionnaireID == id);


            //skal også rettes for create siden!!!!!!!!!!
            var square = _context.QuestionnaireCompetences.Select(i => i.Competence);
            //square indeholder alle competencer der er gemt i databasen.

            if (extraCompetences != null)
            {
                questionnaireToUpdate.QuestionnaireCompetences = new List<QuestionnaireCompetence>();
                foreach (var competence in extraCompetences)
                {
                    //her skal der tilføjes et if statement der chekker om competencen allerede er i listen af competencer, så den ikke står der 2 gange. easy.
                    if (!square.Contains(competence))
                    {

                        var competenceToAdd = new QuestionnaireCompetence
                        {
                            Competence = competence
                        };
                        questionnaireToUpdate.QuestionnaireCompetences.Add(competenceToAdd);
                    }
                }
            }
            //Ovenstående if statement tilføjer de nye competencer der er tilføjet til spørgeskemaet.

            if (questionnaireToUpdate == null)
            {
                return NotFound();
            }

            //Nedenstående var i et if statement før men det gad ikke at virke, så kører bare indholdet altid. easy
            // se i teams filen
            await TryUpdateModelAsync<Questionnaire>(
                questionnaireToUpdate,
                "Questionnaire",
                i => i.Title, i => i.Cycle);
            {




                UpdateQuestionnaireCompetences(_context, selectedQuestionnaireCompetences, questionnaireToUpdate);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            //UpdateEmployeeTeams(_context, selectedTeams, employeeToUpdate);
            //UpdateEmployeeQuestionnaires(_context, selectedQuestionnaires, employeeToUpdate);
            //PopulateAssignedTeamData(_context, employeeToUpdate);
            //PopulateAssignedQuestionnaireData(_context, employeeToUpdate);
            //return Page();
        }

        private bool QuestionnaireExists(int id)
        {
            return _context.Questionnaires.Any(e => e.QuestionnaireID == id);
        }
    }
}
