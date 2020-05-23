using ContosoUniversity.Data;
using ContosoUniversity.Models;
using ContosoUniversity.Models.SchoolViewModels;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Linq;

namespace ContosoUniversity.Pages.Employees
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


        //til at tage spørgeskema
        public void PopulateAssignedEmployeeCompetenceData(TeamberContext context,
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

        //til at vise details siden.
        public void PopulateAssignedEmployeeCompetenceValuesData(TeamberContext context,
                                               Employee employee)
        {
            var questionnaireCompetences = new HashSet<int>(
                employee.EmployeeCompetences.Select(c => c.QuestionnaireCompetenceID)); //fjern select statementet.

            var employeeCompetences = context.EmployeeCompetences;

           
            var employeeQuestionnaires = context.EmpQuestionnaires.Where(i => i.EmployeeID == employee.ID).Select(i => i.QuestionnaireID); //de questionnaires som employeen er medlem af
            var allQuestionnaireCompetences = context.QuestionnaireCompetences.Where(i => employeeQuestionnaires.Contains(i.QuestionnaireID)).Select(i => i.QuestionnaireCompetenceID);
            //alle employeens questionnaires' kompetencer
            //bruges til at se om employeen har angivet en værdi for competencen. Hvis nej: så tilføj den med en værdi på 0.


            AssignedEmployeeCompetenceValuesDataList = new List<AssignedEmployeeCompetenceData>();
            foreach (var competence in allQuestionnaireCompetences)
            {
                if(questionnaireCompetences.Contains(competence)) //altså hvis der er registreret noget data med den competence for emploteen
                {
                    var questionnaireCompetenceID = context.QuestionnaireCompetences.Where(i => i.QuestionnaireCompetenceID == competence).Select(k => k.QuestionnaireID).FirstOrDefault();
                    var competenceName = context.QuestionnaireCompetences.Where(i => i.QuestionnaireCompetenceID == competence).Select(k => k.Competence).FirstOrDefault();
                    var priority = context.EmployeeCompetences.Where(i => i.QuestionnaireCompetenceID == competence).Where(i => i.EmployeeID == employee.ID).Select(k => k.Score).FirstOrDefault();

                    if (employee.EmployeeCompetences.Select(i => i.QuestionnaireCompetenceID).Contains(competence)) //altså hvis den ansatte har et questionnair tilknyttet, hvor competencen er i dette questionnaire.
                    {
                        AssignedEmployeeCompetenceValuesDataList.Add(new AssignedEmployeeCompetenceData
                        {
                            QuestionnaireCompetenceID = competence,
                            Criteria = competenceName,
                            Assigned = true,
                            Priority = priority
                            //Priority = allCompetences.Where(i => i.TeamID == team.TeamID).Where(j => j.QuestionnaireCompetenceID == criteria.QuestionnaireCompetenceID).FirstOrDefault().PriorityValue, //cirkemde med questionnairecompetence id i stedet for team id.

                        });
                    }
                }
                else //så vil vi tilføje den
                {
                    var competenceName = context.QuestionnaireCompetences.Where(i => i.QuestionnaireCompetenceID == competence).Select(k => k.Competence).FirstOrDefault();
                    AssignedEmployeeCompetenceValuesDataList.Add(new AssignedEmployeeCompetenceData
                    {
                        QuestionnaireCompetenceID = competence,
                        Criteria = competenceName,
                        Assigned = true,
                        Priority = 0 //læg mærke til at den sættes til 0. Da employeen jo ikke har angivet en værdi
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
            var employeeQuestionnaires = context.EmpQuestionnaires.Where(i => i.EmployeeID == employeeToUpdate.ID).Select(i => i.QuestionnaireID); //de questionnaires som employeen er medlem af
            var allQuestionnaireCompetences = context.QuestionnaireCompetences.Where(i => employeeQuestionnaires.Contains(i.QuestionnaireID)).Select(i => i.QuestionnaireCompetenceID);
            //alle employeens questionnaires' kompetencer


            int i = 0;
            foreach (var competence in allQuestionnaireCompetences)
            {
                if(employeeToUpdate.EmployeeCompetences.Select(i => i.QuestionnaireCompetenceID).Contains(competence)) //altså hvis han i for vejen har svaret på denne kompetence
                {
                    var currentCompetence = context.EmployeeCompetences.Where(i => i.EmployeeID == employeeToUpdate.ID).Where(i => i.QuestionnaireCompetenceID == competence).FirstOrDefault();
                    currentCompetence.Score = selectedCompetenceValues[i];
                    //competence.Score = selectedCompetenceValues[i];
                }
                else //hvis det er en ny kompetence
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