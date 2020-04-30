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

        public void PopulateAssignedTeamData(SchoolContext context,
                                               Employee employee)
        {
            var allTeams = context.Teams;
            var employeeTeams = new HashSet<int>(
                employee.Enrollments.Select(c => c.TeamID));
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

        public void UpdateEmployeeTeams(SchoolContext context,
            string[] selectedTeams, Employee employeeToUpdate)
        {
            if (selectedTeams == null)
            {
                employeeToUpdate.Enrollments = new List<Enrollment>();
                return;
            }

            var selectedTeamsHS = new HashSet<string>(selectedTeams);
            var employeeTeams = new HashSet<int>
                (employeeToUpdate.Enrollments.Select(c => c.Team.TeamID));
            foreach (var team in context.Teams)
            {
                if (selectedTeamsHS.Contains(team.TeamID.ToString()))
                {
                    if (!employeeTeams.Contains(team.TeamID))
                    {
                        employeeToUpdate.Enrollments.Add(
                            new Enrollment
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
                        Enrollment teamToRemove
                            = employeeToUpdate
                                .Enrollments
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
    }
}