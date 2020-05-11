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
    public class LoginModel : PageModel
    {

        private readonly ContosoUniversity.Data.SchoolContext _context;

        public LoginModel(ContosoUniversity.Data.SchoolContext context)
        {
            _context = context;
        }
        [BindProperty]
        public Employee employee { get; set; }


        [BindProperty]
        public string Username { get; set; }

        [BindProperty]
        public string Password { get; set; }

        public string Msg { get; set; }

        public string Login { get; set; }
        public string Manager { get; set; }


        public void OnGet()
        {


            Login = HttpContext.Session.GetString("username");
            Manager = HttpContext.Session.GetString("Manager");

        }

        public IActionResult OnPost()
        {
            //var allUsername = new List<string>(
            //     _context.Employees.Select(c => c.Username));

            //var allPasswords = new List<string>(
            //    _context.Employees.Select(c => c.Password));

            var allUs = new List<Employee>(
                _context.Employees.Where(c => c.Username == Username));

            var allPass = allUs[0].Password;


            if (allPass == Password)
            {

                if (allUs[0].IsManager == true)
                {
                    HttpContext.Session.SetString("username", Username);
                    return RedirectToPage("/Login/ManagerLogin");

                }
                else
                {
                    HttpContext.Session.SetString("username", Username);
                    return RedirectToPage("Employees/index");


                }
            }
            else
            {
                Msg = "Username or Password invalid";
                return Page();

            }
        }
    }
}
