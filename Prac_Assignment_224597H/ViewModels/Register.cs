using System.ComponentModel.DataAnnotations;

namespace Prac_Assignment_224597H.ViewModels
{
	public class Register
	{

		[Required]
		public string FirstName { get; set; }

		[Required]
		public string LastName { get; set; }

		[Required]
		[DataType(DataType.CreditCard)]
		public string CreditCard { get; set; }

		[Required]
		[Phone]
		[DataType(DataType.PhoneNumber)]
		public string MobileNo { get; set; }

		[Required]
		public string BillingAddress { get; set; }

		[Required]
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
		[DataType(DataType.Password)]
		[Compare(nameof(Password), ErrorMessage = "Password and confirmation password does not match")]
		public string ConfirmPassword { get; set; }

	}
}
