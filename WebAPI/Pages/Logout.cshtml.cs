using System.Threading.Tasks;
using Domain;
using Domain.ApplicationUserAggregate;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebAPI.Pages
{
    public class LogoutModel : PageModel
    {
        private readonly SignInManager<ApplicationUser> signInManager;
        public LogoutModel(SignInManager<ApplicationUser> _signInManager)
        {
            signInManager = _signInManager;
        }

        [BindProperty(SupportsGet = true)]
        public string ReturnUrl { get; set; }
        public async Task<ActionResult> OnPostAsync()
        {
            await signInManager.SignOutAsync();
            return Redirect("/");
        }
    }
}
