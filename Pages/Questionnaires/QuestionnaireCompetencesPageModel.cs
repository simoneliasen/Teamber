using ContosoUniversity.Data;
using ContosoUniversity.Models;
using ContosoUniversity.Models.SchoolViewModels;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Linq;

namespace ContosoUniversity.Pages.Questionnaires
{
    public class QuestionnaireCompetencesPageModel : PageModel
    {
        public List<AssignedQuestionnaireCompetenceData> AssignedQuestionnaireCompetenceDataList;

        public void PopulateAssignedQuestionnaireCompetenceData(SchoolContext context,
                                               Questionnaire questionnaire)
        {
            var allQuestionnaireCompetences = context.QuestionnaireCompetences;
            var questionnaireCompetences = new HashSet<string>( //læg mærke til at det er et hashset af strings
                questionnaire.QuestionnaireCompetences.Select(c => c.Competence)); //og læg mærke til at det er competencer. i form af strings.
            AssignedQuestionnaireCompetenceDataList = new List<AssignedQuestionnaireCompetenceData>();
            foreach (var questionnaireCompetence in allQuestionnaireCompetences)
            {
                if(questionnaireCompetences.Contains(questionnaireCompetence.Competence))
                { 
               
                AssignedQuestionnaireCompetenceDataList.Add(new AssignedQuestionnaireCompetenceData
                {
                    QuestionnaireID = questionnaireCompetence.QuestionnaireID,
                    Competence = questionnaireCompetence.Competence,
                    Assigned = questionnaireCompetences.Contains(questionnaireCompetence.Competence)
                });
                }
            }
        }
        

        public void UpdateQuestionnaireCompetences(SchoolContext context,
            string[] selectedQuestionnaireCompetences, Questionnaire questionnaireToUpdate)
        {
            if (selectedQuestionnaireCompetences == null)
            {
               questionnaireToUpdate.QuestionnaireCompetences = new List<QuestionnaireCompetence>();
                return;
            }

            var selectedCompetencesHS = new HashSet<string>(selectedQuestionnaireCompetences);
            var questionnaireCompetences = new HashSet<string>
                (questionnaireToUpdate.QuestionnaireCompetences.Select(c => c.Competence));
            foreach (var questionnaireCompetence in context.QuestionnaireCompetences)
            {
                if (selectedCompetencesHS.Contains(questionnaireCompetence.Competence))
                {
                    if (!questionnaireCompetences.Contains(questionnaireCompetence.Competence))
                    {
                        questionnaireToUpdate.QuestionnaireCompetences.Add(
                            new QuestionnaireCompetence
                            {
                                QuestionnaireID = questionnaireToUpdate.QuestionnaireID,
                                Competence = questionnaireCompetence.Competence
                            });
                    }
                }
                else
                {
                    if (questionnaireCompetences.Contains(questionnaireCompetence.Competence))
                    {
                        QuestionnaireCompetence competenceToRemove
                            = questionnaireToUpdate
                                .QuestionnaireCompetences
                                .SingleOrDefault(i => i.Competence == questionnaireCompetence.Competence);
                        context.Remove(competenceToRemove);
                    }
                }
            }
        }

        
    }
}
