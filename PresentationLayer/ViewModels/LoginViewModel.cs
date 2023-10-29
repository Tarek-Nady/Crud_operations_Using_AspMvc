using System.ComponentModel.DataAnnotations;

namespace PresentationLayer.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Email is Requred")]
        [EmailAddress(ErrorMessage = "Email is Invalid")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is Required")]
        [MinLength(5, ErrorMessage = "Minimum Password Length is 5")]
        [DataType(DataType.Password)]
        public string Password { get; set; }


        public bool RememberMe { get; set; }
    }
}
