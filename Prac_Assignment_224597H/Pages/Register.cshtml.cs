using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Prac_Assignment_224597H.Model;
using Prac_Assignment_224597H.ViewModels;

namespace Prac_Assignment_224597H.Pages
{
    public class RegisterModel : PageModel
    {
		private UserManager<ApplicationUser> userManager { get; }
		private SignInManager<ApplicationUser> signInManager { get; }
		private readonly string _mySecretKey;

		[BindProperty]
		public Register RModel { get; set; }

		public RegisterModel(UserManager<ApplicationUser> userManager,
		SignInManager<ApplicationUser> signInManager,
		IConfiguration configuration)
		{
			this.userManager = userManager;
			this.signInManager = signInManager;
			_mySecretKey = configuration["MySettings:MySecretKey"];
		}

		public void OnGet()
        {
        }

		public async Task<IActionResult> OnPostAsync()
		{
			if (ModelState.IsValid)
			{
				var dataProtectionProvider = DataProtectionProvider.Create("EncryptData");
				var protector = dataProtectionProvider.CreateProtector(_mySecretKey);

				var user = new ApplicationUser()
				{
					UserName = RModel.Email,
					Email = RModel.Email,
					FirstName = RModel.FirstName,
					LastName = RModel.LastName,
					CreditCard = protector.Protect(RModel.CreditCard),
					MobileNo = RModel.MobileNo,
					BillingAddress = RModel.BillingAddress,
					ShippingAddress = RModel.ShippingAddress,
					/*Photo = RModel.Photo*/
				};
				var result = await userManager.CreateAsync(user, RModel.Password);
				if (result.Succeeded)
				{
					await signInManager.SignInAsync(user, false);
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
