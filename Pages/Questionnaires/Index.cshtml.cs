﻿using ContosoUniversity.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;




namespace ContosoUniversity
{
    public class IndexModel : PageModel
    {
        private readonly ContosoUniversity.Data.SchoolContext _context;

        public IndexModel(ContosoUniversity.Data.SchoolContext context)
        {
            _context = context;
        }

        public string Login { get; set; }
        public string Manager { get; set; }


        public IList<Questionnaire> Questionnaire { get; set; }

        public async Task OnGetAsync()
        {
            Login = HttpContext.Session.GetString("username");
            Manager = HttpContext.Session.GetString("Manager");
            Questionnaire = await _context.Questionnaires.ToListAsync();
        }
    }
}
