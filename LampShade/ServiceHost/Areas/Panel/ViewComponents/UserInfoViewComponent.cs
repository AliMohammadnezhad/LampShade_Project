using System.Threading.Tasks;
using _0_Framework.Application;
using Microsoft.AspNetCore.Mvc;

namespace ServiceHost.Areas.Panel.ViewComponents
{
    public class UserInfoViewComponent:ViewComponent
    {
        private readonly IAuthHelper _authHelper;

        public UserInfoViewComponent(IAuthHelper authHelper)
        {
            _authHelper = authHelper;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            ViewBag.avatar = _authHelper.CurrentAccountInfo().PicturePath;
            ViewBag.FullName = _authHelper.CurrentAccountInfo().Fullname;
            return await Task.FromResult(View());
        }
    }
}
