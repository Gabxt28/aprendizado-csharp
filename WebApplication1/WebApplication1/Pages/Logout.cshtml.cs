using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApplication1.Pages
{
    public class LogoutModel : PageModel
    {
        private SignInManager<IdentityUser> signInManager;

        public LogoutModel(SignInManager<IdentityUser> signInManager)
        {
            this.signInManager = signInManager;
        }
        public void OnGet()
        {
        }
        public async Task<IActionResult> OnPostLogoutAsync()
        {
           await  signInManager.SignOutAsync();
            return RedirectToPage("Login");
        }
        public IActionResult OnPostDontLogout()
        {

            return RedirectToPage("Index");
        }
    }
}
