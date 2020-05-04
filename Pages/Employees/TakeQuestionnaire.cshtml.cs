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

namespace ContosoUniversity.Pages.Employees
{
    public class TakeQuestionnaireModel : EmployeeTeamsPageModel
    {
        private readonly ContosoUniversity.Data.SchoolContext _context;

        public TakeQuestionnaireModel(ContosoUniversity.Data.SchoolContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Employee Employee { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            int id = 11; //id'et sættes bare til id't på den employee der er logget ind. izzyyyy

            if (id == null)
            {
                return NotFound();
            }

            Employee = await _context.Employees
                .Include(k => k.EmpQuestionnaires).ThenInclude(k => k.Questionnaire)
                .FirstOrDefaultAsync(m => m.ID == id);


            // Employee = await _context.Employees.FindAsync(id);

            if (Employee == null)
            {
                return NotFound();
            }

            PopulateAssignedQuestionnaireData(_context, Employee);
            PopulateAssignedEmployeeCompetenceData(_context, Employee);

            return Page();
        }


        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [BindProperty]
        public Team Team { get; set; }


        public async Task<IActionResult> OnPostAsync(string[] selectedCompetences, int[] selectedCompetencesValue) 
        {
            int id = 11; //skal sættes til den der er logget inds id.
            if (id == null)
            {
                return NotFound();
            }

            var employeeToUpdate = await _context.Employees
                .Include(k => k.EmployeeCompetences)
                .FirstOrDefaultAsync(s => s.ID == id);



            if (employeeToUpdate == null)
            {
                return NotFound();
            }

            //  if (await TryUpdateModelAsync<Team>( ????
            await TryUpdateModelAsync<Employee>(
                employeeToUpdate,
                "Employee",
                i => i.PersonalityType);
            {

                UpdateEmployeeCompetences(selectedCompetencesValue, employeeToUpdate);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            //UpdateTeamEmployees(_context, selectedEmployees, teamToUpdate);
            //PopulateAssignedEmployeeData(_context, teamToUpdate);
            return Page();
        }
        private bool TeamExists(int id)
        {
            return _context.Teams.Any(e => e.TeamID == id);
        }
    
    }
}
