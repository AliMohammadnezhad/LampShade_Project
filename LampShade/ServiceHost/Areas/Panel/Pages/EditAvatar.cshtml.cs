using _0_Framework.Application;
using AccountManagement.Application.Contract.Account;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ServiceHost.Areas.Panel.Pages
{
    public class EditAvatarModel : PageModel
    {
        [TempData]
        public string Message { get; set; }
        public UserEditAvatar Command;

        private readonly IAuthHelper _authHelper;
        private readonly IAccountApplication _accountApplication;

        public EditAvatarModel(IAccountApplication accountApplication, IAuthHelper authHelper)
        {
            _accountApplication = accountApplication;
            _authHelper = authHelper;
        }

        public void OnGet()
        {
            Command = _accountApplication.GetAvatar(_authHelper.CurrentAccountId());
        }

        public IActionResult OnPost(UserEditAvatar command)
        {
            if (!ModelState.IsValid)
                return RedirectToPage("/EditAvatar");

            var result = _accountApplication.UserEditAvatar(command);
            Message = result.Message;
            return RedirectToPage("/EditAvatar");
        }
    }
}
