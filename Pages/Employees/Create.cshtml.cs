using Teamber.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Teamber.Pages.Employees
{
    public class CreateModel : EmployeeTeamsPageModel
    {
        private readonly Teamber.Data.TeamberContext _context;

        public CreateModel(Teamber.Data.TeamberContext context)
        {
            _context = context;
        }

        public string Login { get; set; }
        public string Manager { get; set; }

        public IActionResult OnGet()
        {
            Login = HttpContext.Session.GetString("username");
            Manager = HttpContext.Session.GetString("Manager");

            var employee = new Employee();
            employee.EmpTeams = new List<EmpTeam>();
            employee.EmpQuestionnaires = new List<EmpQuestionnaire>();
            // Provides an empty collection for the foreach loop
            // foreach (var course in Model.AssignedCourseDataList)
            // in the Create Razor page.
            PopulateAssignedTeamData(_context, employee);
            PopulateAssignedQuestionnaireData(_context, employee);
            return Page();
        }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [BindProperty]
        public Employee Employee { get; set; }

        public async Task<IActionResult> OnPostAsync(string[] selectedTeams, string[] selectedQuestionnaires)
        {
            var newEmployee = new Employee();
            if (selectedTeams != null)
            {
                newEmployee.EmpTeams = new List<EmpTeam>();
                foreach (var team in selectedTeams)
                {
                    var teamToAdd = new EmpTeam
                    {
                        TeamID = int.Parse(team)
                    };
                    newEmployee.EmpTeams.Add(teamToAdd);
                }
            }
            if (selectedQuestionnaires != null)
            {
                newEmployee.EmpQuestionnaires = new List<EmpQuestionnaire>();
                foreach (var questionnaire in selectedQuestionnaires)
                {
                    var questionnaireToAdd = new EmpQuestionnaire
                    {
                        QuestionnaireID = int.Parse(questionnaire)
                    };
                    newEmployee.EmpQuestionnaires.Add(questionnaireToAdd);
                }

                //sets the employee's competence scores to 0, so that it is easier to edit and see that the employee is registered
                newEmployee.EmployeeCompetences = new List<EmployeeCompetence>();
                var allCompetencesQuestionnaireIDs = new List<int>(
                _context.QuestionnaireCompetences.Select(c => c.QuestionnaireID)); //Retrieves the questionnaire id for all competences

                var allCompetences = new List<int>(
                _context.QuestionnaireCompetences.Select(c => c.QuestionnaireCompetenceID)); //retrieves the competenceID for all competences

                for (int i = 0; i < allCompetencesQuestionnaireIDs.Count(); i++)
                {
                    if (newEmployee.EmpQuestionnaires.Select(i => i.QuestionnaireID).Contains(allCompetencesQuestionnaireIDs[i])) //if the competence's associated questionnaireID is in the list of the employee's associated questionnaires
                                                                                                            //then we want to add the competence with a value of 0 to the employeeCompetences
                    {
                        var competenceToAdd = new EmployeeCompetence
                        {
                            EmployeeID = newEmployee.ID,
                            QuestionnaireCompetenceID = allCompetences[i],
                            Score = 0
                        };

                        newEmployee.EmployeeCompetences.Add(competenceToAdd);
                    }
                }
            }

            // If statement slettet
            await TryUpdateModelAsync<Employee>(
                newEmployee,
                "Employee",
                i => i.FirstMidName, i => i.LastName,
                i => i.EmpTeamDate, i => i.JobTitle,
                i => i.PersonalityType, i => i.IsManager,
                i => i.Username, i => i.Password);
            {

                _context.Employees.Add(newEmployee);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
        }
    }
}
