using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Teamber.Pages
{
    public class IndexModel : PageModel
    {

        public string Login { get; set; }
        public string Manager { get; set; }


        public void OnGet()
        {
            Login = HttpContext.Session.GetString("username");
            Manager = HttpContext.Session.GetString("Manager");

        }
    }
}
