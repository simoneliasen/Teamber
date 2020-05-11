using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ContosoUniversity.Data;
using ContosoUniversity.Models;
using Microsoft.AspNetCore.Http;

namespace ContosoUniversity.Pages.Login
{
    public class LogoutModel : PageModel
    {
        public string Login { get; set; }
        public string Manager { get; set; }

        public IActionResult OnGet()
        {
            HttpContext.Session.Remove("username");
            HttpContext.Session.Remove("Manager");
            return RedirectToPage("Index");
        }

    }
}
