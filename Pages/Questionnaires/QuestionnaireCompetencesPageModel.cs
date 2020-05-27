using Teamber.Data;
using Teamber.Models;
using Teamber.Models.TeamberViewModels;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Linq;

namespace Teamber.Pages.Questionnaires
{
    public class QuestionnaireCompetencesPageModel : PageModel
    {
        public List<AssignedQuestionnaireCompetenceData> AssignedQuestionnaireCompetenceDataList;

        public void PopulateAssignedQuestionnaireCompetenceData(TeamberContext context,
                                               Questionnaire questionnaire)
        {
            var allQuestionnaireCompetences = context.QuestionnaireCompetences;
            var questionnaireCompetences = new HashSet<int>( //Note that this is a hashset of INTS
                questionnaire.QuestionnaireCompetences.Select(c => c.QuestionnaireCompetenceID)); //and note that this is competences in string form
            AssignedQuestionnaireCompetenceDataList = new List<AssignedQuestionnaireCompetenceData>();
            foreach (var questionnaireCompetence in allQuestionnaireCompetences)
            {
                if (questionnaireCompetences.Contains(questionnaireCompetence.QuestionnaireCompetenceID))
                {

                    AssignedQuestionnaireCompetenceDataList.Add(new AssignedQuestionnaireCompetenceData
                    {
                        QuestionnaireID = questionnaireCompetence.QuestionnaireID,
                        Competence = questionnaireCompetence.Competence,
                        Assigned = questionnaireCompetences.Contains(questionnaireCompetence.QuestionnaireCompetenceID),
                        QuestionnaireCompetenceID = questionnaireCompetence.QuestionnaireCompetenceID
                    });
                }
            }
        }

        public void UpdateQuestionnaireCompetences(TeamberContext context,
            string[] selectedQuestionnaireCompetences, Questionnaire questionnaireToUpdate)
        {
            if (selectedQuestionnaireCompetences == null)
            {
                return;
            }

            var selectedCompetencesHS = new HashSet<string>(selectedQuestionnaireCompetences);
            var questionnaireCompetences = new HashSet<string>
                (questionnaireToUpdate.QuestionnaireCompetences.Select(c => c.Competence));

            foreach (var questionnaireCompetence in context.QuestionnaireCompetences)
            {
                if (selectedCompetencesHS.Contains(questionnaireCompetence.Competence))
                {
                    
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
