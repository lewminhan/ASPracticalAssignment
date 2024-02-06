using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Prac_Assignment_224597H.Model;

namespace Prac_Assignment_224597H.Pages
{
    public class LogoutModel : PageModel
    {

		private readonly SignInManager<ApplicationUser> signInManager;

		public LogoutModel(SignInManager<ApplicationUser> signInManager)
		{
			this.signInManager = signInManager;
		}

		public void OnGet()
        {
        }

		public async Task<IActionResult> OnPostLogoutAsync()
		{
			await signInManager.SignOutAsync();
			return RedirectToPage("Login");
		}
		public async Task<IActionResult> OnPostDontLogoutAsync()
		{
			return RedirectToPage("Index");
		}
	}
}
