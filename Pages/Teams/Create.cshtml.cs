using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ContosoUniversity.Data;
using ContosoUniversity.Models;

namespace ContosoUniversity.Pages.Teams {

    public class CreateModel : TeamEmployeesPageModel
    {
        private readonly ContosoUniversity.Data.SchoolContext _context;

        public CreateModel(ContosoUniversity.Data.SchoolContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
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
            return Page();
        }


        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [BindProperty]
        public Team Team { get; set; }


        public async Task<IActionResult> OnPostAsync(string[] selectedEmployees, string[] selectedQuestionnaires, string[] selectedCompetences)
        {
            var newTeam = new Team();
            if (selectedEmployees != null)
            {
                newTeam.EmpTeams = new List<EmpTeam>();
                foreach (var employee in selectedEmployees)
                {
                    var employeeToAdd = new EmpTeam
                    {
                        EmployeeID = int.Parse(employee)
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
