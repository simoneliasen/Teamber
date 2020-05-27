using Teamber.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Linq;

namespace Teamber.Pages.Login {
    public class LoginModel : PageModel {

        private readonly Teamber.Data.TeamberContext _context;

        public LoginModel(Teamber.Data.TeamberContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Employee Employee { get; set; }

        [BindProperty]
        public string Username { get; set; }

        [BindProperty]
        public string Password { get; set; }

        public string ErrorMessage { get; set; }

        // Contain Session value, if user logged in.
        public string Login { get; set; }

        //Contain session value, if manager logged in. 
        public string Manager { get; set; }

        private string LoginPassword { get; set; }

        // Sets the two properties values with the sessions variables. 
        // It then checks on page, if properties are empty. 
        // If not empty the page redirect user to frontpage.
        public void OnGet()
        {
            Login = HttpContext.Session.GetString("username");
            Manager = HttpContext.Session.GetString("Manager");
        }

        public IActionResult OnPost()
        {
            // New list which contain the employee that mathces username in database. 
            var usernameExist = new List<Employee>(
                _context.Employees.Where(c => c.Username == Username));

            // The exception makes sure the system dont crash, if no employee was found above.
            try
            {
                // Gets the password in db from the entered username. 
                LoginPassword = usernameExist[0].Password;
            }
            catch
            {
                ErrorMessage = "Username or Password invalid";
                return Page();
            }

            // The if statement checks if the entered password in page, matches the password of the found username in db. 
            if (LoginPassword == Password)
            {
                // checks if the user thats logs in is manager.
                if (usernameExist[0].IsManager == true)
                {
                    HttpContext.Session.SetString("username", Username);
                    return RedirectToPage("/Login/ManagerLogin");
                }
                // If the user is not manager, the user is logged in as regular employee. 
                else
                {
                    HttpContext.Session.SetString("username", Username);
                    return RedirectToPage("/Employees/Dashboard");
                }
            }
            else
            // If entered password does not match password in db, the same page is returned with errormessage. 
            {
                ErrorMessage = "Username or Password invalid";
                return Page();
            }
        }
    }
}
