using System.Collections.Generic;
using _0_FrameWork.Infrastructure;
using AccountManagement.Application.Contract.Account;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShopManagement.Application.Contracts.Order;
using ShopManagement.Configuration.Permissions;

namespace ServiceHost.Areas.Administration.Pages.Orders
{
    public class IndexModel : PageModel
    {
        public OrderSearchModel SearchModel;
        public SelectList Accounts;
        public List<OrderViewModel> Orders;

        private readonly IOrderApplication _orderApplication;
        private readonly IAccountApplication _accountApplication;

        public IndexModel(IOrderApplication orderApplication, IAccountApplication accountApplication)
        {
            _orderApplication = orderApplication;
            _accountApplication = accountApplication;
        }
        [NeedsPermission(ShopPermissions.SearchOrders)]
        public void OnGet(OrderSearchModel searchModel)
        {
            Accounts = new SelectList(_accountApplication.GetAccounts(), "Id", "FullName");
            Orders = _orderApplication.Search(searchModel);
        }
        [NeedsPermission(ShopPermissions.ConfirmOrder)]

        public IActionResult OnGetConfirm(long id)
        {
            _orderApplication.PaymentSucceeded(id, 0);
            return RedirectToPage("./Index");
        }
        [NeedsPermission(ShopPermissions.CancelOrder)]

        public IActionResult OnGetCancel(long id)
        {
            _orderApplication.Cancel(id);
            return RedirectToPage("./Index");
        }
        [NeedsPermission(ShopPermissions.ShowOrderItems)]

        public IActionResult OnGetItems(long id)
        {
            var items = _orderApplication.GetOrderItemsBy(id);
            return Partial("Items", items);
        }

        public IActionResult OnGetAddress(long id)
        {
            var address = _orderApplication.GetOrderAddressByOrder(id).OrderAddress;
            return Partial("Address", address);

        }

    }
}