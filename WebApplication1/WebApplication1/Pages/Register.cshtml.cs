using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplication1.ViewModels;

namespace WebApplication1.Pages
{
    public class RegisterModel : PageModel
    {
        private UserManager<IdentityUser> userManager;
        private SignInManager<IdentityUser> signInManager;



        [BindProperty]

        public Register Model { get; set; }
        public RegisterModel(UserManager<IdentityUser> UserManager, SignInManager<IdentityUser> signInManager)
        {
            this.userManager = UserManager;
            this.signInManager = signInManager; 
        }
 
        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                var user = new IdentityUser()
                {
                    UserName = Model.Email,
                    Email = Model.Email
                };
             var result = await  userManager.CreateAsync(user, Model.Passowrd);

                if (result.Succeeded) {

                  await  signInManager.SignInAsync(user, false);
                    return RedirectToPage("Index");
                
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            
            
            }
            return Page();
        }
    }
}
