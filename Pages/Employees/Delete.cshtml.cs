﻿using Teamber.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Teamber.Pages.Employees
{
    public class DeleteModel : PageModel
    {
        private readonly Teamber.Data.TeamberContext _context;

        public DeleteModel(Teamber.Data.TeamberContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Employee Employee { get; set; }
        public string ErrorMessage { get; set; }

        public string Login { get; set; }
        public string Manager { get; set; }


        public async Task<IActionResult> OnGetAsync(int? id, bool? saveChangesError = false)
        {
            Login = HttpContext.Session.GetString("username");
            Manager = HttpContext.Session.GetString("Manager");

            if (id == null)
            {
                return NotFound();
            }

            Employee = await _context.Employees
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.ID == id);

            if (Employee == null)
            {
                return NotFound();
            }

            if (saveChangesError.GetValueOrDefault())
            {
                ErrorMessage = "Delete failed. Try again";
            }

            return Page();
        }



        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Employee employee = await _context.Employees
               .Include(i => i.EmpTeams)
               .SingleAsync(i => i.ID == id);

            if (employee == null)
            {
                return RedirectToPage("./Index");
            }


            _context.Employees.Remove(employee);

            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
