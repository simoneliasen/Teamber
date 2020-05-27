﻿using Teamber.Data;
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
            var questionnaireCompetences = new HashSet<int>( //læg mærke til at det er et hashset af ints
                questionnaire.QuestionnaireCompetences.Select(c => c.QuestionnaireCompetenceID)); //og læg mærke til at det er competencer. i form af strings.
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
                //questionnaireToUpdate.QuestionnaireCompetences = new List<QuestionnaireCompetence>();
                return;
            }

            var selectedCompetencesHS = new HashSet<string>(selectedQuestionnaireCompetences);
            var questionnaireCompetences = new HashSet<string>
                (questionnaireToUpdate.QuestionnaireCompetences.Select(c => c.Competence));

            foreach (var questionnaireCompetence in context.QuestionnaireCompetences)
            {
                if (selectedCompetencesHS.Contains(questionnaireCompetence.Competence))
                {
                    /*
                    if (!questionnaireCompetences.Contains(questionnaireCompetence.Competence))
                    {
                        questionnaireToUpdate.QuestionnaireCompetences.Add(
                            new QuestionnaireCompetence
                            {
                                QuestionnaireID = questionnaireToUpdate.QuestionnaireID,
                                Competence = questionnaireCompetence.Competence
                            });
                    } */
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
