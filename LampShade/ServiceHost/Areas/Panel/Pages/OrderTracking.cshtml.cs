using _0_Framework.Application;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShopManagement.Application.Contracts.Order;

namespace ServiceHost.Areas.Panel.Pages
{
    public class OrderTrackingModel : PageModel
    {
        public OrderViewModel Command;

        private readonly IAuthHelper _authHelper;
        private readonly IOrderApplication _orderApplication;

        public OrderTrackingModel(IAuthHelper authHelper, IOrderApplication orderApplication)
        {
            _authHelper = authHelper;
            _orderApplication = orderApplication;
        }

        public void OnGet(string? issueNumber)
        {
            if (issueNumber != null)
            {
               Command = _orderApplication.GetOrderBy(_authHelper.CurrentAccountId(), issueNumber);
            }
        }
    }
}
