using System.Collections.Generic;
using _0_Framework.Application;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShopManagement.Application.Contracts.Order;

namespace ServiceHost.Areas.Panel.Pages
{
    public class OrdersModel : PageModel
    {
        public List<OrderViewModel> Orders;

        private readonly IAuthHelper _authHelper;
        private readonly IOrderApplication _orderApplication;
        public OrdersModel(IOrderApplication orderApplication, IAuthHelper authHelper)
        {
            _orderApplication = orderApplication;
            _authHelper = authHelper;
        }

        public void OnGet()
        {
            var orderSearchModel = new OrderSearchModel()
            {
                AccountId = _authHelper.CurrentAccountId()
            };
            Orders = _orderApplication.Search(orderSearchModel);
        }

        public IActionResult OnGetItems(long id)
        {
            var orderItemViewModels = _orderApplication.GetOrderItemsBy(id);
            return Partial("./OrderItems", orderItemViewModels);
        }
    }
}


