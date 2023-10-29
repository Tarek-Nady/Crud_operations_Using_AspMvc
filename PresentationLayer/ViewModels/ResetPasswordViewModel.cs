using System.ComponentModel.DataAnnotations;

namespace PresentationLayer.ViewModels
{
    public class ResetPasswordViewModel
    {

        [Required(ErrorMessage = "Password is Required")]
        [MinLength(5, ErrorMessage = "Minimum Password Length is 5")]
        [DataType(DataType.Password)]
        public string NewPassword { get; set; }

        [Required(ErrorMessage = "Confirm Password is Required")]
        [Compare("NewPassword", ErrorMessage = "Confrim Password Does Not Match Password")]
        [DataType(DataType.Password)]

        public string ConfirmPassword { get; set; }


        public string  Token { get; set; }

        public string Email { get; set; }

    }
}
