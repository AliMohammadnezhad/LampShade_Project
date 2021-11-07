using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using _0_Framework.Application;
using _0_FrameWork.Application.ZarinPal;
using _01_LampShadeQueries.Contracts.Product;
using _01_LampShadeQueries.Contracts.ShopOrder;
using Microsoft.AspNetCore.Http;
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
        private readonly ICartService _cartService;
        private readonly IProductQuery _productQuery;
        private readonly IOrderApplication _orderApplication;
        private readonly IZarinPalFactory _zarinPalFactory;

        public CheckOutModel(ICartCalculateService calculateService, IAuthHelper authHelper, ICartService cartService, IProductQuery productQuery, IOrderApplication orderApplication, IZarinPalFactory zarinPalFactory)
        {
            _calculateService = calculateService;
            _authHelper = authHelper;
            _cartService = cartService;
            _productQuery = productQuery;
            _orderApplication = orderApplication;
            _zarinPalFactory = zarinPalFactory;
        }

        public IActionResult OnGet()
        {
            var serializer = new JavaScriptSerializer();
            var cartCookie = Request.Cookies[CookieName];
            if (cartCookie == null)
                return RedirectToPage("/Index");
            if (!_authHelper.IsAuthenticated())
                return RedirectToPage("/Account");
            var item = serializer.Deserialize<List<CartItem>>(cartCookie);
            item.ForEach(x => x.CalculateTotalPrice());

            CheckOutCart = _calculateService.ComputeCart(item);
            _cartService.Set(CheckOutCart);

            return null;
        }

        public IActionResult OnPostPay(long paymentMethod)
        {
            var cart = _cartService.Get();
            cart.SetPaymentMethod(paymentMethod);
            var result = _productQuery.CheckCartItemInventoryStatus(cart.CartItems);
            if (result.Any(x => !x.InStock))
                return Redirect("/Cart");
            var currentUserId = _authHelper.CurrentAccountId();
            var orderId = _orderApplication.PlaceOrder(cart, currentUserId);
            var accountInfo = _authHelper.CurrentAccountInfo();
            if (paymentMethod == 1)
            {
                var paymentResponse = _zarinPalFactory.CreatePaymentRequest(cart.CartForPayAmount.ToString(CultureInfo.InvariantCulture), "09140336758",
                    "ali@ali.com", "فروشگاه لوازم دکوری", orderId);


                return Redirect($"https://{paymentResponse.Perfix}.zarinpal.com/pg/StartPay/" + paymentResponse.Authority);
            }
            else
            {
                var paymentResult = new PaymentResult();
                paymentResult.Succeeded("");
                var jsonResult = new JavaScriptSerializer().Serialize(paymentResult);
                Response.Cookies.Append("PayResult", jsonResult, new CookieOptions { Expires = DateTime.Now.AddMinutes(2), Path = "/" });
                Response.Cookies.Delete(CookieName);

                return RedirectToPage("/FinalCheckout", jsonResult);

            }
        }

        public IActionResult OnGetCallBack([FromQuery] string authority, [FromQuery] string status,
            [FromQuery] long oId)
        {
            var orderPrice = _orderApplication.GetOrderPriceBy(oId);
            var response = _zarinPalFactory.CreateVerificationRequest(authority, orderPrice);

            var paymentResult = new PaymentResult();
            if (status == "OK" && (response.Status == 100 || response.Status == 101))
            {
                var issueTrackingNo = _orderApplication.PaymentSucceeded(oId, response.RefId);
                paymentResult.Succeeded(issueTrackingNo);
                Response.Cookies.Delete(CookieName);
                var paymentModel = new JavaScriptSerializer().Serialize(paymentResult);
                Response.Cookies.Append("PayResult", paymentModel, new CookieOptions { Expires = DateTime.Now.AddMinutes(2), Path = "/" });
                return RedirectToPage("/FinalCheckout");
            }

            paymentResult.Failed();
            var failPaymentResult = new JavaScriptSerializer().Serialize(paymentResult);
            Response.Cookies.Append("PayResult", failPaymentResult, new CookieOptions { Expires = DateTime.Now.AddMinutes(2), Path = "/" });

            return RedirectToPage("/FinalCheckout");
        }
    }
}
