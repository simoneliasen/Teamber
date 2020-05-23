﻿using ContosoUniversity.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace ContosoUniversity.Pages.Teams
{
    public class IndexModel : TeamEmployeesPageModel
    {
        private readonly ContosoUniversity.Data.TeamberContext _context;

        public IndexModel(ContosoUniversity.Data.TeamberContext context)
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
