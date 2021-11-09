using _0_Framework.Application;
using AccountManagement.Application.Contract.Account;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ServiceHost.Areas.Panel.Pages
{
    public class IndexModel : PageModel
    {
 
        public new PanelAccountViewModel User { get; set; }
        private readonly IAccountApplication _accountApplication;
        private readonly IAuthHelper _authHelper;

        public IndexModel(IAccountApplication accountApplication, IAuthHelper authHelper)
        {
            _accountApplication = accountApplication;
            _authHelper = authHelper;
        }

        public void OnGet()
        {
            User = _accountApplication.GetAccountBy(_authHelper.CurrentAccountId());

        }
    }
}
