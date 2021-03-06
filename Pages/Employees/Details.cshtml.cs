﻿using Teamber.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;


namespace Teamber.Pages.Employees
{
    public class DetailsModel : EmployeeTeamsPageModel
    {
        private readonly Teamber.Data.TeamberContext _context;

        public DetailsModel(Teamber.Data.TeamberContext context)
        {
            _context = context;
        }

        public string Login { get; set; }
        public string Manager { get; set; }

        public Employee Employee { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            Login = HttpContext.Session.GetString("username");
            Manager = HttpContext.Session.GetString("Manager");

            if (id == null)
            {
                return NotFound();
            }

            Employee = await _context.Employees
       .Include(s => s.EmpTeams)
       .ThenInclude(e => e.Team)
       .Include(x => x.EmpQuestionnaires)
       .ThenInclude(k => k.Questionnaire)
       .Include(i => i.EmployeeCompetences)
       .AsNoTracking()
       .FirstOrDefaultAsync(m => m.ID == id);

            PopulateAssignedEmployeeCompetenceValuesData(_context, Employee);

            if (Employee == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
