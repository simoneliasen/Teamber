using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ContosoUniversity.Pages.Login
{
    public class ManagerLoginModel : PageModel
    {
        public string Managerlogin = "Managerlogin";
        public string Login { get; set; }
        public string Manager { get; set; }



        public void OnGet()
        {
            Login = HttpContext.Session.GetString("username");
            Manager = HttpContext.Session.GetString("Manager");

        }
        public IActionResult OnPost(string submitchoice)
        {

            if (submitchoice == "LoginAsManager")
            {

                HttpContext.Session.SetString("Manager", Managerlogin);
                return RedirectToPage("/index");


            }
            else
            {

                return RedirectToPage("/index");

            }


        }
    }
}
