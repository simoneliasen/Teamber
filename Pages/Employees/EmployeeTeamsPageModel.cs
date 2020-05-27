using Teamber.Data;
using Teamber.Models;
using Teamber.Models.TeamberViewModels;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Linq;

namespace Teamber.Pages.Employees
{
    public class EmployeeTeamsPageModel : PageModel
    {

        public List<AssignedTeamData> AssignedTeamDataList;
        public List<AssignedQuestionnaireData> AssignedQuestionnaireDataList;
        public List<AssignedEmployeeCompetenceData> AssignedEmployeeCompetenceDataList;
        public List<AssignedEmployeeCompetenceData> AssignedEmployeeCompetenceValuesDataList;

        public void PopulateAssignedTeamData(TeamberContext context,
                                               Employee employee)
        {
            var allTeams = context.Teams;
            var employeeTeams = new HashSet<int>(
                employee.EmpTeams.Select(c => c.TeamID));
            AssignedTeamDataList = new List<AssignedTeamData>();
            foreach (var team in allTeams)
            {
                AssignedTeamDataList.Add(new AssignedTeamData
                {
                    TeamID = team.TeamID,
                    Title = team.Title,
                    Assigned = employeeTeams.Contains(team.TeamID)
                });
            }
        }

        public void PopulateAssignedQuestionnaireData(TeamberContext context,
                                               Employee employee)
        {
            var allQuestionnaires = context.Questionnaires;
            var employeeQuestionnaires = new HashSet<int>(
                employee.EmpQuestionnaires.Select(c => c.QuestionnaireID));
            AssignedQuestionnaireDataList = new List<AssignedQuestionnaireData>();
            foreach (var questionnaire in allQuestionnaires)
            {
                AssignedQuestionnaireDataList.Add(new AssignedQuestionnaireData
                {
                    QuestionnaireID = questionnaire.QuestionnaireID,
                    Title = questionnaire.Title,
                    Assigned = employeeQuestionnaires.Contains(questionnaire.QuestionnaireID)
                });
            }
        }


        //for taking a questionnaire
        public void PopulateAssignedEmployeeCompetenceData(TeamberContext context,
                                               Employee employee)
        {
            var questionnaireCompetences = new HashSet<int>(
                employee.EmpQuestionnaires.Select(c => c.QuestionnaireID));


            //note: this retrieves all competences - not just the employeeCompetences. Meaning when you take the questionnaire, you cant see your previous answers.
            var allCompetences = context.QuestionnaireCompetences;


            AssignedEmployeeCompetenceDataList = new List<AssignedEmployeeCompetenceData>();
            foreach (var competence in allCompetences)
            {
                var questionnaireID = context.QuestionnaireCompetences.Where(i => i.QuestionnaireCompetenceID == competence.QuestionnaireCompetenceID).Select(k => k.QuestionnaireID).FirstOrDefault();
                var competenceName = context.QuestionnaireCompetences.Where(i => i.QuestionnaireCompetenceID == competence.QuestionnaireCompetenceID).Select(k => k.Competence).FirstOrDefault();

                if (employee.EmpQuestionnaires.Select(i => i.QuestionnaireID).Contains(competence.QuestionnaireID)) //meaning, if the employee is associated with a questionnaire, where the competence is in this questionnaire
                {
                    AssignedEmployeeCompetenceDataList.Add(new AssignedEmployeeCompetenceData
                    {
                        QuestionnaireID = questionnaireID,
                        Criteria = competenceName,
                        Assigned = true,
                        Priority = 1,
                        QuestionnaireCompetenceID = competence.QuestionnaireCompetenceID
                    });
                }
            }
        }

        //for showing the details page
        public void PopulateAssignedEmployeeCompetenceValuesData(TeamberContext context,
                                               Employee employee)
        {
            var questionnaireCompetences = new HashSet<int>(
                employee.EmployeeCompetences.Select(c => c.QuestionnaireCompetenceID));

            var employeeCompetences = context.EmployeeCompetences;

           
            var employeeQuestionnaires = context.EmpQuestionnaires.Where(i => i.EmployeeID == employee.ID).Select(i => i.QuestionnaireID); //the questionnaires that are associated with the employee
            var allQuestionnaireCompetences = context.QuestionnaireCompetences.Where(i => employeeQuestionnaires.Contains(i.QuestionnaireID)).Select(i => i.QuestionnaireCompetenceID);
            //all the employee's questionnaires' competences
            //is used to check if the employee has rates the competence. If not, then add it with a value of 0.


            AssignedEmployeeCompetenceValuesDataList = new List<AssignedEmployeeCompetenceData>();
            foreach (var competence in allQuestionnaireCompetences)
            {
                if(questionnaireCompetences.Contains(competence)) //meaning, if there is registered any data for this competence for the employee
                {
                    var questionnaireCompetenceID = context.QuestionnaireCompetences.Where(i => i.QuestionnaireCompetenceID == competence).Select(k => k.QuestionnaireID).FirstOrDefault();
                    var competenceName = context.QuestionnaireCompetences.Where(i => i.QuestionnaireCompetenceID == competence).Select(k => k.Competence).FirstOrDefault();
                    var priority = context.EmployeeCompetences.Where(i => i.QuestionnaireCompetenceID == competence).Where(i => i.EmployeeID == employee.ID).Select(k => k.Score).FirstOrDefault();

                    if (employee.EmployeeCompetences.Select(i => i.QuestionnaireCompetenceID).Contains(competence)) //meaning, if the employee is associated with a questionnaire, where the competence is inn this questionnaire
                    {
                        AssignedEmployeeCompetenceValuesDataList.Add(new AssignedEmployeeCompetenceData
                        {
                            QuestionnaireCompetenceID = competence,
                            Criteria = competenceName,
                            Assigned = true,
                            Priority = priority

                        });
                    }
                }
                else //then we want to add it
                {
                    var competenceName = context.QuestionnaireCompetences.Where(i => i.QuestionnaireCompetenceID == competence).Select(k => k.Competence).FirstOrDefault();
                    AssignedEmployeeCompetenceValuesDataList.Add(new AssignedEmployeeCompetenceData
                    {
                        QuestionnaireCompetenceID = competence,
                        Criteria = competenceName,
                        Assigned = true,
                        Priority = 0 //note it is set to 0, as the employee havent entered any data.
                    });
                }
                
            }
        }




        public void UpdateEmployeeTeams(TeamberContext context,
            string[] selectedTeams, Employee employeeToUpdate)
        {
            if (selectedTeams == null)
            {
                employeeToUpdate.EmpTeams = new List<EmpTeam>();
                return;
            }

            var selectedTeamsHS = new HashSet<string>(selectedTeams);
            var employeeTeams = new HashSet<int>
                (employeeToUpdate.EmpTeams.Select(c => c.Team.TeamID));
            foreach (var team in context.Teams)
            {
                if (selectedTeamsHS.Contains(team.TeamID.ToString()))
                {
                    if (!employeeTeams.Contains(team.TeamID))
                    {
                        employeeToUpdate.EmpTeams.Add(
                            new EmpTeam
                            {
                                EmployeeID = employeeToUpdate.ID,
                                TeamID = team.TeamID
                            });
                    }
                }
                else
                {
                    if (employeeTeams.Contains(team.TeamID))
                    {
                        EmpTeam teamToRemove
                            = employeeToUpdate
                                .EmpTeams
                                .SingleOrDefault(i => i.TeamID == team.TeamID);
                        context.Remove(teamToRemove);
                    }
                }
            }
        }

        public void UpdateEmployeeQuestionnaires(TeamberContext context,
            string[] selectedQuestionnaires, Employee employeeToUpdate)
        {
            if (selectedQuestionnaires == null)
            {
                employeeToUpdate.EmpQuestionnaires = new List<EmpQuestionnaire>();
                return;
            }

            var selectedQuestionnairesHS = new HashSet<string>(selectedQuestionnaires);
            var employeeQuestionnaires = new HashSet<int>
                (employeeToUpdate.EmpQuestionnaires.Select(c => c.Questionnaire.QuestionnaireID));
            foreach (var questionnaire in context.Questionnaires)
            {
                if (selectedQuestionnairesHS.Contains(questionnaire.QuestionnaireID.ToString()))
                {
                    if (!employeeQuestionnaires.Contains(questionnaire.QuestionnaireID))
                    {
                        employeeToUpdate.EmpQuestionnaires.Add(
                            new EmpQuestionnaire
                            {
                                EmployeeID = employeeToUpdate.ID,
                                QuestionnaireID = questionnaire.QuestionnaireID
                            });
                    }
                }
                else
                {
                    if (employeeQuestionnaires.Contains(questionnaire.QuestionnaireID))
                    {
                        EmpQuestionnaire questionnaireToRemove
                            = employeeToUpdate
                                .EmpQuestionnaires
                                .SingleOrDefault(i => i.QuestionnaireID == questionnaire.QuestionnaireID);
                        context.Remove(questionnaireToRemove);
                    }
                }
            }
        }



        public void UpdateEmployeeCompetences(TeamberContext context, int[] selectedCompetenceValues, Employee employeeToUpdate)
        {
            var employeeQuestionnaires = context.EmpQuestionnaires.Where(i => i.EmployeeID == employeeToUpdate.ID).Select(i => i.QuestionnaireID); //the employee's associated questionnaires
            var allQuestionnaireCompetences = context.QuestionnaireCompetences.Where(i => employeeQuestionnaires.Contains(i.QuestionnaireID)).Select(i => i.QuestionnaireCompetenceID);
            //all of the employee's questionnaires' competences


            int i = 0;
            foreach (var competence in allQuestionnaireCompetences)
            {
                if(employeeToUpdate.EmployeeCompetences.Select(i => i.QuestionnaireCompetenceID).Contains(competence)) //meaning, if he already have answered it.
                {
                    var currentCompetence = context.EmployeeCompetences.Where(i => i.EmployeeID == employeeToUpdate.ID).Where(i => i.QuestionnaireCompetenceID == competence).FirstOrDefault();
                    currentCompetence.Score = selectedCompetenceValues[i];
                }
                else //if the competence is new
                {
                    var competenceToAdd = new EmployeeCompetence
                    {
                        EmployeeID = employeeToUpdate.ID,
                        QuestionnaireCompetenceID = competence,
                        Score = selectedCompetenceValues[i]
                };

                    employeeToUpdate.EmployeeCompetences.Add(competenceToAdd);
                }



                i++;

            }
        }
    }
}