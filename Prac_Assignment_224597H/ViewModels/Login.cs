using System.ComponentModel.DataAnnotations;

namespace Prac_Assignment_224597H.ViewModels
{
    public class Login
    {

        [Required]
        [EmailAddress]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public bool RememberMe { get; set; }

    }
}
