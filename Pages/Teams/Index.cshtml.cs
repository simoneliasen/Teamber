using Teamber.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Teamber.Pages.Teams
{
    public class IndexModel : TeamEmployeesPageModel
    {
        private readonly Teamber.Data.TeamberContext _context;

        public IndexModel(Teamber.Data.TeamberContext context)
        {
            _context = context;
        }

        public string Login { get; set; }
        public string Manager { get; set; }


        public IList<Team> Team { get; set; }

        public async Task OnGetAsync()
        {

            Login = HttpContext.Session.GetString("username");
            Manager = HttpContext.Session.GetString("Manager");

            Team = await _context.Teams.ToListAsync();

            PopulateTeamMemberCount(_context);
        }
    }
}
