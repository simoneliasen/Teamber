using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Teamber.Pages.Login {
    public class ManagerLoginModel : PageModel {
        public string Login { get; set; }
        public string Manager { get; set; }
        public string Managerlogin = "Managerlogin";

        public void OnGet()
        {
            Login = HttpContext.Session.GetString("username");
            Manager = HttpContext.Session.GetString("Manager");
        }

        // checks if user have selected manger or employee in form at pagemodel. 
        public IActionResult OnPost(string submitchoice)
        {
            if (submitchoice == "Manager")
            {
                // If user have selected manager, a addtionel manager sessions is started. 
                // The sessions contains the string "Manager".
                HttpContext.Session.SetString("Manager", Managerlogin);
                return RedirectToPage("/Teams/index");
            }
            else
            {
                return RedirectToPage("/Employees/Dashboard");
            }
        }
    }
}
