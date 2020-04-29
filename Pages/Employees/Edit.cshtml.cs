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

namespace ContosoUniversity.Pages.Employees {


    public class EditModel : EmployeeTeamsPageModel
        {
        private readonly ContosoUniversity.Data.SchoolContext _context;

        public EditModel(ContosoUniversity.Data.SchoolContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Employee Employee { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Employee = await _context.Employees
                .Include(i => i.Enrollments).ThenInclude(i => i.Team)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.ID == id);


           // Employee = await _context.Employees.FindAsync(id);

            if (Employee == null)
            {
                return NotFound();
            }
            PopulateAssignedTeamData(_context, Employee);

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id, string[] selectedTeams)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employeeToUpdate = await _context.Employees
                .Include(i => i.Enrollments)
                    .ThenInclude(i => i.Team)
                .FirstOrDefaultAsync(s => s.ID == id);

            if (employeeToUpdate == null)
            {
                return NotFound();
            }

            if (await TryUpdateModelAsync<Employee>(
                employeeToUpdate,
                "Employee",
                i => i.FirstMidName, i => i.LastName,
                i => i.EnrollmentDate))
                {
           
                UpdateEmployeeTeams(_context, selectedTeams, employeeToUpdate);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            UpdateEmployeeTeams(_context, selectedTeams, employeeToUpdate);
            PopulateAssignedTeamData(_context, employeeToUpdate);
            return Page();
        }

        /*
        public async Task<IActionResult> OnPostAsync(int id)
        {
            var employeeToUpdate = await _context.Employees.FindAsync(id);

            if (employeeToUpdate == null)
            {
                return NotFound();
            }

            if (await TryUpdateModelAsync<Employee>(
                employeeToUpdate,
                "employee",
                s => s.FirstMidName, s => s.LastName, s => s.EnrollmentDate))
            {
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }

            return Page();
        }
        */
        private bool EmployeeExists(int id)
        {
            return _context.Employees.Any(e => e.ID == id);
        }
    }
}
