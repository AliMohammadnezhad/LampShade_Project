using System.ComponentModel.DataAnnotations;
using _0_Framework.Application;

namespace AccountManagement.Application.Contract.Account
{
    public class UserEditAccount
    {
        [Required]
        [MaxLength(100,ErrorMessage = ValidationMessages.MaxLength)]
        public string FullName { get; set; }
        [Required]
        [MaxLength(100, ErrorMessage = ValidationMessages.MaxLength)]
        public string Mobile { get; set; }

        public long AccountId { get; set; }

    }
}
