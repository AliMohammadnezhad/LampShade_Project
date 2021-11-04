using System.ComponentModel.DataAnnotations;
using _0_Framework.Application;

namespace AccountManagement.Application.Contract.Account
{
   public class RegisterAccountViewModel
    {
        [MaxLength(150, ErrorMessage = ValidationMessages.MaxLength)]
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string FullName { get; set; }
        [MaxLength(150, ErrorMessage = ValidationMessages.MaxLength)]
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string Username { get; set; }
        [MaxLength(1000, ErrorMessage = ValidationMessages.MaxLength)]
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string Password { get; set; }
        [Compare("Password",ErrorMessage = ValidationMessages.PasswordsNotMatch)]
        public string RePassword { get; set; }
        [MaxLength(11, ErrorMessage = ValidationMessages.MaxLength)]
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string Mobile { get; set; }


    }
}
