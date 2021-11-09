using _0_Framework.Application;
using _0_FrameWork.Application;
using Microsoft.AspNetCore.Http;

namespace AccountManagement.Application.Contract.Account
{
    public class UserEditAvatar
    {
        [MaxFileSize(3 * 1024 * 1024, ErrorMessage = ValidationMessages.MaxFileSize)]
        [FileExtensionLimitation(new[] { ".jpg", ".png", ".jpeg" })]
        public IFormFile Picture { get; set; }
        public long AccountId { get; set; }
        public string PicturePath { get; set; }
    }
}
