using ContosoUniversity.Data;
using ContosoUniversity.Models;
using ContosoUniversity.Models.SchoolViewModels;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Linq;

namespace ContosoUniversity.Pages.Employees {
    public class EmployeeTeamsPageModel : PageModel {

        public List<AssignedTeamData> AssignedTeamDataList;
        public List<AssignedQuestionnaireData> AssignedQuestionnaireDataList;
        public List<AssignedEmployeeCompetenceData> AssignedEmployeeCompetenceDataList;

        public void PopulateAssignedTeamData(SchoolContext context,
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

        public void PopulateAssignedQuestionnaireData(SchoolContext context,
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


        //til at tage spørgeskema
        public void PopulateAssignedEmployeeCompetenceData(SchoolContext context,
                                               Employee employee)
        {
            var questionnaireCompetences = new HashSet<int>(
                employee.EmpQuestionnaires.Select(c => c.QuestionnaireID));


            //obs: den henter alle competencer - ikke bare employeeCompetences. Dvs. når man tager questionnairet kan man ikke se hvad man svarede sidst.
            var allCompetences = context.QuestionnaireCompetences;


            AssignedEmployeeCompetenceDataList = new List<AssignedEmployeeCompetenceData>();
            foreach (var competence in allCompetences)
            {
                var questionnaireID = context.QuestionnaireCompetences.Where(i => i.QuestionnaireCompetenceID == competence.QuestionnaireCompetenceID).Select(k => k.QuestionnaireID).FirstOrDefault();
                var competenceName = context.QuestionnaireCompetences.Where(i => i.QuestionnaireCompetenceID == competence.QuestionnaireCompetenceID).Select(k => k.Competence).FirstOrDefault();

                if (employee.EmpQuestionnaires.Select(i => i.QuestionnaireID).Contains(competence.QuestionnaireID)) //altså hvis den ansatte har et questionnair tilknyttet, hvor competencen er i dette questionnaire.
                {
                    AssignedEmployeeCompetenceDataList.Add(new AssignedEmployeeCompetenceData
                    {
                        QuestionnaireID = questionnaireID,
                        Criteria = competenceName,
                        Assigned = true,
                        Priority = 1,
                        //Priority = allCompetences.Where(i => i.TeamID == team.TeamID).Where(j => j.QuestionnaireCompetenceID == criteria.QuestionnaireCompetenceID).FirstOrDefault().PriorityValue, //cirkemde med questionnairecompetence id i stedet for team id.
                        QuestionnaireCompetenceID = competence.QuestionnaireCompetenceID
                    });
                }
            }
        }

        public void UpdateEmployeeTeams(SchoolContext context,
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

        public void UpdateEmployeeQuestionnaires(SchoolContext context,
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



        public void UpdateEmployeeCompetences(int[] selectedCompetenceValues, Employee employeeToUpdate)
        {
            int i = 0;
            foreach (var competence in employeeToUpdate.EmployeeCompetences)
            {
                competence.Score = selectedCompetenceValues[i];
                i++;
            }
        }
    }
}