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
                .Include(i => i.EmpTeams).ThenInclude(i => i.Employee)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.TeamID == id);


            // Employee = await _context.Employees.FindAsync(id);

            if (Team == null)
            {
                return NotFound();
            }
            PopulateAssignedEmployeeData(_context, Team);

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id, string[] selectedEmployees)
        {
            if (id == null)
            {
                return NotFound();
            }

            var teamToUpdate = await _context.Teams
                .Include(i => i.EmpTeams)
                .ThenInclude(i => i.Employee)
                .FirstOrDefaultAsync(s => s.TeamID == id);

            if (teamToUpdate == null)
            {
                return NotFound();
            }

            if (await TryUpdateModelAsync<Team>(
                teamToUpdate,
                "Team",
                i => i.Title))
            {

                UpdateTeamEmployees(_context, selectedEmployees, teamToUpdate);
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








    /*public class EditModel : PageModel
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

           Team = await _context.Teams.FirstOrDefaultAsync(m => m.TeamID == id);

           if (Team == null)
           {
               return NotFound();
           }
           return Page();
       }

       // To protect from overposting attacks, please enable the specific properties you want to bind to, for
       // more details see https://aka.ms/RazorPagesCRUD.
       public async Task<IActionResult> OnPostAsync()
       {
           if (!ModelState.IsValid)
           {
               return Page();
           }

           _context.Attach(Team).State = EntityState.Modified;

           try
           {
               await _context.SaveChangesAsync();
           }
           catch (DbUpdateConcurrencyException)
           {
               if (!TeamExists(Team.TeamID))
               {
                   return NotFound();
               }
               else
               {
                   throw;
               }
           }

           return RedirectToPage("./Index");
       }

       private bool TeamExists(int id)
       {
           return _context.Teams.Any(e => e.TeamID == id);
       }
   } */
}
