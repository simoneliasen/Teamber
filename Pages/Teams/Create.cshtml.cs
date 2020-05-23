using ContosoUniversity.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace ContosoUniversity.Pages.Teams {
    public class CreateModel : TeamEmployeesPageModel {
        private readonly ContosoUniversity.Data.TeamberContext _context;

        public CreateModel(ContosoUniversity.Data.TeamberContext context)
        {
            _context = context;
        }

        public string Login { get; set; }
        public string Manager { get; set; }

        public IActionResult OnGet()
        {
            Login = HttpContext.Session.GetString("username");
            Manager = HttpContext.Session.GetString("Manager");

            var team = new Team();
            team.EmpTeams = new List<EmpTeam>();
            team.TeamQuestionnaires = new List<TeamQuestionnaire>();
            team.TeamCriterias = new List<TeamCriteria>();

            // Provides an empty collection for the foreach loop
            // foreach (var course in Model.AssignedCourseDataList)
            // in the Create Razor page.
            PopulateAssignedEmployeeData(_context, team);
            PopulateAssignedQuestionnaireData(_context, team);
            PopulateAllCompetencesData(_context, team);
            PopulateAllEmpCompetencesString(_context);
            PopulateAllEmpQuestionnairesString(_context);
            PopulateAllQuestionnairesString(_context);
            PopulateAllQuestionnaireTitlesString(_context);
            return Page();
        }

        [BindProperty]
        public Team Team { get; set; }

        public async Task<IActionResult> OnPostAsync(string[] selectedEmployees, string[] selectedQuestionnaires, string[] selectedCompetences, int[] selectedCompetencesValue) //skal det være string eller int?
        {
            var newTeam = new Team();

            if (selectedEmployees != null)
            {
                newTeam.EmpTeams = new List<EmpTeam>();
                foreach (var employee in selectedEmployees)
                {
                    string[] employeeSplit = employee.Split("-");
                    string employeeIDString = employeeSplit[0];
                    string employeeField = employeeSplit[employeeSplit.Length - 1]; //altså den sidste.

                    var employeeToAdd = new EmpTeam
                    {
                        EmployeeID = int.Parse(employeeIDString),
                        questionnaireRole = employeeField
                    };
                    newTeam.EmpTeams.Add(employeeToAdd);
                }
            }

            if (selectedQuestionnaires != null)
            {
                newTeam.TeamQuestionnaires = new List<TeamQuestionnaire>();
                foreach (var questionnaire in selectedQuestionnaires)
                {
                    var questionnaireToAdd = new TeamQuestionnaire
                    {
                        QuestionnaireID = int.Parse(questionnaire)
                    };
                    newTeam.TeamQuestionnaires.Add(questionnaireToAdd);
                }

                //tilføjer kriterier for de enkelte felter for de tilhørende questionnaires.
                newTeam.TeamCriterias = new List<TeamCriteria>();
                for (int i = 0; i < selectedCompetences.Length; i++)
                {
                    var criteriaToAdd = new TeamCriteria
                    {
                        QuestionnaireCompetenceID = int.Parse(selectedCompetences[i]),
                        PriorityValue = selectedCompetencesValue[i]
                    };

                    if (criteriaToAdd.PriorityValue > 0) //alle dem der ikke skal bruges sættes bare til 0. Så vi tager kun dem der skal bruges.
                    {
                        newTeam.TeamCriterias.Add(criteriaToAdd);
                    }

                }
            }

            await TryUpdateModelAsync<Team>(
                newTeam,
                "Team",
                i => i.Title, i => i.Synergy);
            {
                _context.Teams.Add(newTeam);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }

            PopulateAssignedEmployeeData(_context, newTeam);
            return Page();
        }
    }
}
