using System.ComponentModel.DataAnnotations;
using _0_Framework.Application;

namespace AccountManagement.Application.Contract.Account
{
    public class UserEditPassword
    {
        
        public string Password { get; set; }
        [Compare("Password",ErrorMessage = ValidationMessages.PasswordsNotMatch)]
        public string RePassword { get; set; }
        public long AccountId { get; set; }
    }
}
