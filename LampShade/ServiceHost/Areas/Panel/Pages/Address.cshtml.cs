using _0_Framework.Application;
using AccountManagement.Application.Contract.Account;
using AccountManagement.Application.Contract.Address;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ServiceHost.Areas.Panel.Pages
{
    public class AddressModel : PageModel
    {
        [TempData]
        public string Message { get; set; }

        public EditAddress Command;
        public long AccountId { get; set; }
        private readonly IAuthHelper _authHelper;
        private readonly IAddressApplication _addressApplication;
        public AddressModel(IAuthHelper authHelper, IAddressApplication addressApplication)
        {
            _authHelper = authHelper;
            _addressApplication = addressApplication;
        }

        public void OnGet()
        {
            Command = _addressApplication.GetDetail(_authHelper.CurrentAccountId());
            AccountId = _authHelper.CurrentAccountId();

        }

        public IActionResult OnPost(EditAddress command)
        {
            if (!ModelState.IsValid)
                return RedirectToPage("/Address");

            if (_addressApplication.UserHasAddress(_authHelper.CurrentAccountId()))
            {
                Message = _addressApplication.Edit(command).Message;
                return RedirectToPage("/Address");
            }
            else
            {
                Message = _addressApplication.Create(command).Message;
                return RedirectToPage("/Address");


            }

        }


    }
}
