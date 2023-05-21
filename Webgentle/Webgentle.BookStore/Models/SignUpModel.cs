

using System.ComponentModel.DataAnnotations;

namespace Webgentle.BookStore.Models
{
    public class SignUpModel
    {
        [Required(ErrorMessage = "please enter email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "please enter password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "please enter confirmPassword")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "confirmpassword doesn't match ")]
        public string ConfirmPassword { get; set; }
    }
}
