using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ContosoUniversity.Data;
using ContosoUniversity.Models;
  
namespace ContosoUniversity.Pages.Employees {
    public class DetailsModel : PageModel {
        private readonly ContosoUniversity.Data.SchoolContext _context;

        public DetailsModel(ContosoUniversity.Data.SchoolContext context)
        {
            _context = context;
        }

        public Employee Employee { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Employee = await _context.Employees
       .Include(s => s.EmpTeams)
       .ThenInclude(e => e.Team)
       .Include(x => x.EmpQuestionnaires)
       .ThenInclude(k => k.Questionnaire)
       .AsNoTracking()
       .FirstOrDefaultAsync(m => m.ID == id);


            if (Employee == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
