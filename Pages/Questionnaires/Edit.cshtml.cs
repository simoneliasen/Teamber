using Teamber.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Teamber.Pages.Questionnaires
{
    public class EditModel : QuestionnaireCompetencesPageModel
    {
        private readonly Teamber.Data.TeamberContext _context;

        public EditModel(Teamber.Data.TeamberContext context)
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
            //this variable contains the competences that the user wants to add to the questionnaire. Meaning the commma-separated textbox.

            if (id == null)
            {
                return NotFound();
            }

            var questionnaireToUpdate = await _context.Questionnaires
                .Include(i => i.QuestionnaireCompetences)
                .FirstOrDefaultAsync(s => s.QuestionnaireID == id);

            //square contains all competences saved in the database.

            if (extraCompetences != null)
            {
                foreach (var competence in extraCompetences)
                {
                        var competenceToAdd = new QuestionnaireCompetence
                        {
                            Competence = competence
                        };
                        questionnaireToUpdate.QuestionnaireCompetences.Add(competenceToAdd);
                    
                }
            }
            //the above if statement adds the new competences to the questionnaire


            //This part removes the checked competences. (The user checks the competences that should be removed)
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

            await TryUpdateModelAsync<Questionnaire>(
                questionnaireToUpdate,
                "Questionnaire",
                i => i.Title);
            {


                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
        }

        private bool QuestionnaireExists(int id)
        {
            return _context.Questionnaires.Any(e => e.QuestionnaireID == id);
        }
    }
}
