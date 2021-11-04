using AccountManagement.Application.Contract.Role;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;

namespace ServiceHost.Areas.Administration.Pages.Accounts.Role
{
    public class IndexModel : PageModel
    {
        [TempData]
        public string Message { get; set; }
        public List<RoleViewModel> Roles;

        private readonly IRoleApplication _roleApplication;

        public IndexModel(IRoleApplication roleApplication)
        {
            _roleApplication = roleApplication;
        }

        public void OnGet()
        {
            Roles = _roleApplication.List();
        }
    }
}
