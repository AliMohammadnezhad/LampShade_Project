using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using _0_Framework.Application;
using _0_FrameWork.Application;
using AccountManagement.Application.Contract.Role;
using Microsoft.AspNetCore.Http;

namespace AccountManagement.Application.Contract.Account
{
    public class CreateAccount
    {
        [MaxLength(150,ErrorMessage = ValidationMessages.MaxLength)]
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string FullName { get; set; }
        [MaxLength(150, ErrorMessage = ValidationMessages.MaxLength)]
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string Username { get; set; }
        [MaxLength(1000, ErrorMessage = ValidationMessages.MaxLength)]
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string Password { get; set; }
        [MaxLength(11, ErrorMessage = ValidationMessages.MaxLength)]
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string Mobile { get; set; }
        [Range(1,100000,ErrorMessage = ValidationMessages.MaxLength)]
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public long RoleId { get; set; }
        [MaxFileSize(3*1024*1024,ErrorMessage = ValidationMessages.MaxFileSize)]
        [FileExtensionLimitation(new []{".jpg", ".png",".jpeg" })]
        public IFormFile ProfilePhoto { get; set; }
        public List<RoleViewModel> Roles { get; set; }
    }
}
