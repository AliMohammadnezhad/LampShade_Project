using _0_Framework.Application;
using AccountManagement.Application.Contract.Account;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ServiceHost.Areas.Panel.Pages
{
    public class ChangePasswordModel : PageModel
    {
        [TempData]
        public string Message { get; set; }
        public UserEditPassword Command;

        private readonly IAuthHelper _authHelper;
        private readonly IAccountApplication _accountApplication;

        public ChangePasswordModel(IAccountApplication accountApplication, IAuthHelper authHelper)
        {
            _accountApplication = accountApplication;
            _authHelper = authHelper;
        }

        public void OnGet()
        {

        }

        public IActionResult OnPost(UserEditPassword command)
        {
            command.AccountId = _authHelper.CurrentAccountId();

            if (!ModelState.IsValid)
                return RedirectToPage("./ChangePassword");

            var result = _accountApplication.UserEditPassword(command);
            Message = result.Message;
            _authHelper.SignOut();
            return RedirectToPage("./ChangePassword");

        }
    }
}
