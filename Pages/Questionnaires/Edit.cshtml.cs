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
        private readonly ContosoUniversity.Data.TeamberContext _context;

        public EditModel(ContosoUniversity.Data.TeamberContext context)
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



        public async Task<IActionResult> OnPostAsync(int? id, int[] selectedQuestionnaireCompetences)
        {

            //evt lav første array til "c#, php, php", "".
            //og så split index 0 op i flere så "c#", "php", "mysql"
          

            //get competences from form, and add as string
            string tagOutput = Request.Form["myField"];
            Questionnaire.CompetencesString = tagOutput;



            string[] extraCompetences;
            if (Questionnaire.CompetencesString != null && Questionnaire.CompetencesString != "Questionnaire.CompetencesString")
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
            //var square = _context.QuestionnaireCompetences.Select(i => i.Competence);
            //square indeholder alle competencer der er gemt i databasen.

            if (extraCompetences != null)
            {
                //det skal vel ikke laves til en ny list? det er vel bare derfor den fjerner de andre??????????????????????????????
                //questionnaireToUpdate.QuestionnaireCompetences = new List<QuestionnaireCompetence>();
                foreach (var competence in extraCompetences)
                {
                        var competenceToAdd = new QuestionnaireCompetence
                        {
                            Competence = competence
                        };
                        questionnaireToUpdate.QuestionnaireCompetences.Add(competenceToAdd);
                    
                }
            }
            //Ovenstående if statement tilføjer de nye competencer der er tilføjet til spørgeskemaet.


            //nu fjerner vi dem der er checked.
            foreach(var competence in selectedQuestionnaireCompetences)
            {
                QuestionnaireCompetence competenceToRemove
                    = questionnaireToUpdate
                        .QuestionnaireCompetences
                        .SingleOrDefault(i => i.QuestionnaireCompetenceID == competence);
                try
                {
                    _context.Remove(competenceToRemove);
                }
                catch(Exception)
                {

                }
               
            }


            if (questionnaireToUpdate == null)
            {
                return NotFound();
            }

            //Nedenstående var i et if statement før men det gad ikke at virke, så kører bare indholdet altid. easy
            // se i teams filen
            await TryUpdateModelAsync<Questionnaire>(
                questionnaireToUpdate,
                "Questionnaire",
                i => i.Title);
            {


                //UpdateQuestionnaireCompetences(_context, selectedQuestionnaireCompetences, questionnaireToUpdate);
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
