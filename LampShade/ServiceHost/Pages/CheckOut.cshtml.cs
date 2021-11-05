using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _0_Framework.Application;
using _01_LampShadeQueries.Contracts.ShopOrder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Nancy.Json;
using ShopManagement.Application.Contracts.Order;

namespace ServiceHost.Pages
{
    public class CheckOutModel : PageModel
    {
        public Cart CheckOutCart;
        private const string CookieName = "cart-items";
        private readonly ICartCalculateService _calculateService;
        private readonly IAuthHelper _authHelper;

        public CheckOutModel(ICartCalculateService calculateService, IAuthHelper authHelper)
        {
            _calculateService = calculateService;
            _authHelper = authHelper;
        }

        public IActionResult OnGet()
        {
            var serializer = new JavaScriptSerializer();
            var cartCookie = Request.Cookies[CookieName];

            if (!_authHelper.IsAuthenticated())
               return RedirectToPage("/Account");
            var item = serializer.Deserialize<List<CartItem>>(cartCookie);
            item.ForEach(x => x.CalculateTotalPrice());

            CheckOutCart = _calculateService.ComputeCart(item);
            return null;
        }
    }
}
