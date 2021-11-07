using System;
using System.Collections.Generic;
using System.Linq;
using _0_Framework.Application;
using _01_LampShadeQueries.Contracts.ShopOrder;
using AccountManagement.Application.Contract.Account;
using AccountManagement.Infrastructure.EFCore;
using DiscountManagement.infrastructure.EFCore;
using ShopManagement.Application.Contracts.Order;

namespace _01_LampShadeQueries.Queries
{
    public class CartCalculateService : ICartCalculateService
    {
        private readonly AccountContext _accountContext;
        private readonly IAuthHelper _authHelper;
        private readonly DiscountContext _discountContext;

        public CartCalculateService(DiscountContext discountContext, IAuthHelper authHelper, AccountContext accountContext)
        {
            _discountContext = discountContext;
            _authHelper = authHelper;
            _accountContext = accountContext;
        }

        public Cart ComputeCart(List<CartItem> cartItems)
        {
            
            var result = new Cart();
            var currentUserRole = int.Parse(_authHelper.CurrentAccountRole());
            var discount = new List<DiscountModel>();

            if (currentUserRole == AccountsType.ColleagueUser)
            {
                discount = _discountContext.ColleagueDiscounts.Where(x => !x.IsRemoved).Select(x => new DiscountModel
                {
                    DiscountRate = x.DiscountRate,
                    ProductId = x.ProductId
                }).ToList();

            }
            else
            {
                discount = _discountContext.CustomerDiscounts.Where(x => x.EndDate > DateTime.Now)
                    .Select(x => new DiscountModel
                    {
                        DiscountRate = x.DiscountRate,
                        ProductId = x.ProductId
                    }).ToList();
            }


            foreach (var item in cartItems)
            {
                item.DiscountRate = discount.FirstOrDefault(x => x.ProductId == item.Id)?.DiscountRate;
                if (item.DiscountRate > 0)
                {
                    item.DiscountAmount = (item.UnitPrice * item.DiscountRate.Value) / 100;
                    item.ItemPayAmount = (item.TotalPrice - item.DiscountAmount);
                }
                else
                {
                    item.DiscountRate = 0;
                    item.DiscountAmount = (item.UnitPrice * 0) / 100;
                    item.ItemPayAmount = (item.TotalPrice - item.DiscountAmount);
                }

       

                result.Add(item);
            }
            
            return result;
        }


    }

    public class DiscountModel
    {
        public long ProductId { get; set; }
        public int DiscountRate { get; set; }
    }

    
}