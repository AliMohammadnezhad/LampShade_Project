using System.Collections.Generic;
using System.Linq;
using _0_FrameWork.Infrastructure;
using AccountManagement.Application.Contract.Role;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ServiceHost.Areas.Administration.Pages.Accounts.Role
{
    public class EditModel : PageModel
    {
        public EditRole Command;
        public List<SelectListItem> Permissions = new List<SelectListItem>();
        private readonly IRoleApplication _roleApplication;
        private readonly IEnumerable<IPermissionExposer> _exposers;
        public EditModel(IRoleApplication roleApplication, IEnumerable<IPermissionExposer> exposers)
        {
            _roleApplication = roleApplication;
            _exposers = exposers;
        }

        public void OnGet(long id)
        {
            Command = _roleApplication.GetDetails(id);
            foreach (var exposer in _exposers)
            {
                var exposedPermission = exposer.Expose();
                foreach (var (key,value) in exposedPermission)
                {
                    var group = new SelectListGroup
                    {
                        Name = key
                    };
                    foreach (var permissionDto in value)
                    {
                        var item = new SelectListItem(permissionDto.Name, permissionDto.Code.ToString())
                        {
                            Group = group
                        };

                        if (Command.MappedPermissions.Any(x => x.Code == permissionDto.Code))
                            item.Selected = true;

                        Permissions.Add(item);

                    }
                }
            }
        }

        public IActionResult OnPost(EditRole command)
        {
            var result = _roleApplication.Edit(command);
            return RedirectToPage("Index");
        }
    }
}