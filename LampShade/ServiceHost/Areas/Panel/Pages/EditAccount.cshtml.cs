using _0_Framework.Application;
using AccountManagement.Application.Contract.Account;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ServiceHost.Areas.Panel.Pages
{
    public class EditAccountModel : PageModel
    {
        [TempData]
        public string Message { get; set; }
        public UserEditAccount Command;

        private readonly IAccountApplication _accountApplication;
        private readonly IAuthHelper _authHelper;
        public EditAccountModel(IAccountApplication accountApplication, IAuthHelper authHelper)
        {
            _accountApplication = accountApplication;
            _authHelper = authHelper;
        }


        public void OnGet(long id)
        {
            Command = _accountApplication.GetDetailEditAccount(_authHelper.CurrentAccountId());
        }

        public IActionResult OnPost(UserEditAccount command)
        {
            if (!ModelState.IsValid)
                return RedirectToPage("./EditAccount");
            var result = _accountApplication.UserEditAccount(command);
            Message = result.Message;
            return RedirectToPage("./Index");
        }
    }
}
