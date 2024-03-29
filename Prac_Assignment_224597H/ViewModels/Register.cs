﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Prac_Assignment_224597H.ViewModels
{
	public class Register
	{

		[Required]
		[Display(Name = "First Name")]
        [DataType(DataType.Text)]
        public string FirstName { get; set; }

		[Required]
        [Display(Name = "Last Name")]
        [DataType(DataType.Text)]
        public string LastName { get; set; }

		[Required]
        [Display(Name = "Credit Card No")]
        [RegularExpression(@"^\d{16}$", ErrorMessage = "Credit Card Number must be exactly 16 digits")]
        [DataType(DataType.CreditCard)]
		public string CreditCard { get; set; }

		[Required]
		[Phone]
        [Display(Name = "Mobile No")]
        [RegularExpression(@"^\d{8}$", ErrorMessage = "Mobile Number must be exactly 8 digits")]
        [DataType(DataType.PhoneNumber)]
		public string MobileNo { get; set; }

		[Required]
        [Display(Name = "Billing Address")]
        [DataType(DataType.Text)]
        public string BillingAddress { get; set; }

		[Required]
        [Display(Name = "Shipping Address")]
        [DataType(DataType.Text)]
        public string ShippingAddress { get; set; }

		[Required]
		[EmailAddress]
		[DataType(DataType.EmailAddress)]
		public string Email { get; set; }

		[Required]
		[RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{12,}$", ErrorMessage = "Password must be a minimum of 12 characters and include a combination of lower-case, upper-case, numbers, and special characters.")]
		[DataType(DataType.Password)]
		public string Password { get; set; }

		[Required]
        [Display(Name = "Confirm Password")]
        [DataType(DataType.Password)]
		[Compare(nameof(Password), ErrorMessage = "Password and confirmation password does not match")]
		public string ConfirmPassword { get; set; }

		/*[Required]
		[NotMapped]
		[Display(Name = "Profile Picture")]
		[DataType(DataType.Upload)]
		[FileExtensions(Extensions = ".jpg", ErrorMessage = "Only .jpg files are allowed")]
		public IFormFile Photo { get; set; }*/
	}
}
