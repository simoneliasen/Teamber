using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Teamber.Pages.Login {
    public class LogoutModel : PageModel {
        public string Login { get; set; }
        public string Manager { get; set; }

        public IActionResult OnGet()
        {
            HttpContext.Session.Remove("username");
            HttpContext.Session.Remove("Manager");
            return RedirectToPage("/Index");
        }
    }
}
