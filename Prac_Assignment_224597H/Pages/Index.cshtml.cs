using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Prac_Assignment_224597H.Model;

namespace Prac_Assignment_224597H.Pages
{
	[Authorize]
	public class IndexModel : PageModel
	{
        private readonly UserManager<ApplicationUser> userManager;
        private readonly ILogger<IndexModel> _logger;
        private readonly string _mySecretKey;
		public ApplicationUser UserDetail { get; set; }

        public IndexModel(ILogger<IndexModel> logger,
            UserManager<ApplicationUser> userManager,
            IConfiguration configuration)
		{
			_logger = logger;
            this.userManager = userManager;
            _mySecretKey = configuration["MySettings:MySecretKey"];
        }

		public void OnGet()
		{
            var dataProtectionProvider = DataProtectionProvider.Create("EncryptData");
            var protector = dataProtectionProvider.CreateProtector(_mySecretKey);

            UserDetail = userManager.GetUserAsync(User).Result;

            ViewData["CreditCard"] = protector.Unprotect(UserDetail.CreditCard);

        }
	}
}
