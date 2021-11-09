using System;
using System.Collections.Generic;
using System.Linq;
using _0_Framework.Application;
using _01_LampShadeQueries.Contracts.Product;
using AccountManagement.Application.Contract.Address;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Nancy.Json;
using ShopManagement.Application.Contracts.Order;

namespace ServiceHost.Pages
{
    public class CartModel : PageModel
    {
        public List<CartItem> CartItems;
        public bool HasAddress { get; set; } = true;
        private const string CookieName = "cart-items";

        private readonly IAuthHelper _authHelper;
        private readonly IProductQuery _productQuery;
        private readonly IAddressApplication _addressApplication;

        public CartModel(IProductQuery productQuery, IAuthHelper authHelper, IAddressApplication addressApplication)
        {
            _productQuery = productQuery;
            _authHelper = authHelper;
            _addressApplication = addressApplication;
        }

        public void OnGet()
        {
            var serializer = new JavaScriptSerializer();
            var cartCookie = Request.Cookies[CookieName];
            if(cartCookie == null)
                return;

            var item = serializer.Deserialize<List<CartItem>>(cartCookie);
            item.ForEach(x=>x.CalculateTotalPrice());

            CartItems = _productQuery.CheckCartItemInventoryStatus(item);

        }

        public IActionResult OnGetRemoveFromCart(int id)
        {
            var serializer = new JavaScriptSerializer();
            var cartCookie = Request.Cookies[CookieName];
            Response.Cookies.Delete(CookieName);
            var cartItems = serializer.Deserialize<List<CartItem>>(cartCookie);

            var itemForRemove = cartItems.FirstOrDefault(x => x.Id == id);
            cartItems.Remove(itemForRemove);

            var cookie = serializer.Serialize(cartItems);
            var options = new CookieOptions()
            {
                Expires = DateTime.Now.AddDays(2)
            };

            Response.Cookies.Append(CookieName,cookie,options);
            return RedirectToPage("/Cart");
        }


        public IActionResult OnGetGotoCheckOut()
        {
            var serializer = new JavaScriptSerializer();
            var cartCookie = Request.Cookies[CookieName];
            if (cartCookie == null)
                return RedirectToPage("/Cart");

            var item = serializer.Deserialize<List<CartItem>>(cartCookie);
            item.ForEach(x => x.TotalPrice = (x.UnitPrice * x.Count));

            CartItems = _productQuery.CheckCartItemInventoryStatus(item);
            if(CartItems.Any(x=>!x.InStock))
                return RedirectToPage("/Cart");

            if (!_addressApplication.UserHasAddress(_authHelper.CurrentAccountId()))
            {
                HasAddress = false;
                return RedirectToPage("/Cart");

            }


            return RedirectToPage("/CheckOut");
        }
    }
}
