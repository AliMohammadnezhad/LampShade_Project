using AccountManagement.Application.Contract.Account;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ServiceHost.Pages
{
    public class AccountModel : PageModel
    {
        [TempData]
        public string LoginMessage { get; set; }
        [TempData]
        public string RegisterMessage { get; set; }
        private readonly IAccountApplication _accountApplication;
        public RegisterAccountViewModel Command;
        public AccountModel(IAccountApplication accountApplication)
        {
            _accountApplication = accountApplication;
        }


        public void OnGet()
        {
        }

        public IActionResult OnPostLogin(LoginViewModel command)
        {
            var operationResult = _accountApplication.Login(command);
            if (operationResult.IsSucceed)
                return RedirectToPage("/Index");
            LoginMessage = operationResult.Message;
            return RedirectToPage("./Account");
        }

        public IActionResult OnPostRegister(RegisterAccountViewModel command)
        {
            if (!ModelState.IsValid)
                return RedirectToPage("./Account");

            var account = new CreateAccount
            {
                Username = command.Username,
                Mobile = command.Mobile,
                FullName = command.FullName,
                Password = command.Password,
                RoleId = AccountsType.SystemUser
            };

            var operationResult = _accountApplication.Create(account);
            if(operationResult.IsSucceed)
                return RedirectToPage("/Account");
            RegisterMessage = operationResult.Message;
            return RedirectToPage("./Account");
        }

        public IActionResult OnGetLogout()
        {
            _accountApplication.Logout();
            return RedirectToPage("/Index");
        }

    }
}
