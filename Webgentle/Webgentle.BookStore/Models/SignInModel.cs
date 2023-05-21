using System.ComponentModel.DataAnnotations;

namespace Webgentle.BookStore.Models
{
    public class SignInModel
    {
        [Required(ErrorMessage = "please enter email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "please enter password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public bool RememberMe { get; set; }
    }
}