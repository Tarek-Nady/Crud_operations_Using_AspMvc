using System.ComponentModel.DataAnnotations;

namespace PresentationLayer.ViewModels
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage ="Email is Requred")]
        [EmailAddress(ErrorMessage ="Email is Invalid")]
        public string Email { get; set; }

        [Required(ErrorMessage ="Password is Required")]
        [MinLength(5,ErrorMessage ="Minimum Password Length is 5")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Confirm Password is Required")]
        [Compare("Password",ErrorMessage ="Confrim Password Does Not Match Password")]
        [DataType(DataType.Password)]

        public string ConfirmPassword { get; set; }

        public bool IsAgree { get; set; }
    }
}
