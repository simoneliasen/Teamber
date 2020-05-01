using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ContosoUniversity.Data;
using ContosoUniversity.Models;

namespace ContosoUniversity.Pages.Teams {

    public class EditModel : TeamEmployeesPageModel
    {
        private readonly ContosoUniversity.Data.SchoolContext _context;

        public EditModel(ContosoUniversity.Data.SchoolContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Team Team { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Team = await _context.Teams
                .Include(i => i.EmpTeams).ThenInclude(i => i.Employee).
                Include(k => k.TeamQuestionnaires).ThenInclude(k => k.Questionnaire)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.TeamID == id);


            // Employee = await _context.Employees.FindAsync(id);

            if (Team == null)
            {
                return NotFound();
            }
            PopulateAssignedEmployeeData(_context, Team);
            PopulateAssignedQuestionnaireData(_context, Team);

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id, string[] selectedEmployees, string[] selectedQuestionnaires )
        {
            if (id == null)
            {
                return NotFound();
            }

            var teamToUpdate = await _context.Teams
                .Include(i => i.EmpTeams)
                .ThenInclude(i => i.Employee)
                .Include(k => k.TeamQuestionnaires).ThenInclude(k => k.Questionnaire)
                .FirstOrDefaultAsync(s => s.TeamID == id);



            if (teamToUpdate == null)
            {
                return NotFound();
            }

            //  if (await TryUpdateModelAsync<Team>( ????
            await TryUpdateModelAsync<Team>(
                teamToUpdate,
                "Team",
                i => i.Title, i => i.Synergy);
            {

                UpdateTeamEmployees(_context, selectedEmployees, teamToUpdate);
                UpdateTeamQuestionnaires(_context, selectedQuestionnaires, teamToUpdate);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            UpdateTeamEmployees(_context, selectedEmployees, teamToUpdate);
            PopulateAssignedEmployeeData(_context, teamToUpdate);
            return Page();
        }
        private bool TeamExists(int id)
        {
            return _context.Teams.Any(e => e.TeamID == id);
        }
    }
}
