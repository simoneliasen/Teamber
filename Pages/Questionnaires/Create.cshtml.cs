﻿using ContosoUniversity.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContosoUniversity
{
    public class CreateModel : PageModel
    {
        private readonly ContosoUniversity.Data.SchoolContext _context;

        public CreateModel(ContosoUniversity.Data.SchoolContext context)
        {
            _context = context;
        }

        public string Login { get; set; }
        public string Manager { get; set; }


        public IActionResult OnGet()
        {
            Login = HttpContext.Session.GetString("username");
            Manager = HttpContext.Session.GetString("Manager");

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
            string[] selectedQuestionnaireCompetences;

            //get competences from form, and add as string
            string tagOutput = Request.Form["myField"];
            Questionnaire.CompetencesString = tagOutput;


            if (Questionnaire.CompetencesString != null)
            {
                selectedQuestionnaireCompetences = Questionnaire.CompetencesString.Split(", ");
            }
            else
            {
                selectedQuestionnaireCompetences = null;
            }

            var square = _context.QuestionnaireCompetences.Select(i => i.Competence);
            //square indeholder alle competencer der er gemt i databasen.
            //drop database og se om det virker.

            var newQuestionnaire = new Questionnaire();
            if (selectedQuestionnaireCompetences != null)
            {
                newQuestionnaire.QuestionnaireCompetences = new List<QuestionnaireCompetence>();
                foreach (var competence in selectedQuestionnaireCompetences)
                {
                    if (!square.Contains(competence))
                    {
                        var competenceToAdd = new QuestionnaireCompetence
                        {
                            Competence = competence
                        };
                        newQuestionnaire.QuestionnaireCompetences.Add(competenceToAdd);
                    }
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
