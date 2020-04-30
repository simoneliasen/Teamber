using ContosoUniversity.Models.SchoolViewModels;
using ContosoUniversity.Data;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ContosoUniversity.Models;

namespace ContosoUniversity.Pages
{
    public class AboutModel : PageModel
    {
        private readonly SchoolContext _context;

        public AboutModel(SchoolContext context)
        {
            _context = context;
        }

        public IList<EmpTeamDateGroup> Employees { get; set; }

        public async Task OnGetAsync()
        {
            IQueryable<EmpTeamDateGroup> data =
                from employee in _context.Employees
                group employee by employee.EmpTeamDate into dateGroup
                select new EmpTeamDateGroup()
                {
                    EmpTeamDate = dateGroup.Key,
                    EmployeeCount = dateGroup.Count()
                };

            Employees = await data.AsNoTracking().ToListAsync();
        }
    }
}
