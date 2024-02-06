﻿using Microsoft.AspNetCore.Identity;

namespace Prac_Assignment_224597H.Model
{
	public class ApplicationUser : IdentityUser
	{
		public string FirstName { get; set; }

		public string LastName { get; set; }

		public string CreditCard { get; set; }

		public string MobileNo { get; set; }

		public string BillingAddress { get; set; }

		public string ShippingAddress { get; set; }
	}
}
