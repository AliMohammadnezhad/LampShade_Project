using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using _0_Framework.Application;
using _0_FrameWork.Infrastructure;
using AccountManagement.Infrastructure.EFCore;
using ShopManagement.Application.Contracts.Order;
using ShopManagement.Domain.OrderAgg;

namespace ShopManagement.Infrastructure.EFCore.Repository
{
   public class OrderRepository:RepositoryBase<long,Order>,IOrderRepository
   {
       private readonly ShopContext _shopContext;
       private readonly AccountContext _accountContext;
        public OrderRepository(ShopContext context, AccountContext accountContext) : base(context)
        {
            _shopContext = context;
            _accountContext = accountContext;
        }

        public double GetOrderPriceBy(long id)
        {
            var orderPrice = _shopContext.Orders.Select(x => new {x.PayAmount, x.Id}).FirstOrDefault(x => x.Id == id).PayAmount;
            if (orderPrice > 0)
                return orderPrice;
            return 0;
        }

        public Order GetOrderBy(long userId)
        {
            return _shopContext.Orders.Where(x=>x.IsCanceled == false && x.IsPaid == false).FirstOrDefault(x => x.AccountId == userId);
        }

        public List<OrderViewModel> Search()
        {
            var account = _accountContext.Accounts.Select(x => new
            {
                x.FullName,
                x.Id
            }).ToList();
            var query = _shopContext.Orders.Select(x => new OrderViewModel
            {
                IssueTrackingNo = x.IssueTrackingNo,
                DiscountAmount = x.DiscountAmount,
                RefId = x.RefId,
                TotalAmount = x.TotalAmount,
                PaymentMethodId = x.PaymentMethod,
                IsPaid = x.IsPaid,
                IsCanceled = x.IsCanceled,
                PayAmount = x.PayAmount,
                AccountId = x.AccountId,
                DateTime = x.CreationDate.ToFarsi(),
                OrderId = x.Id,
                OrderItems = x.Items.Select(m=>new OrderItemViewModel
                {
                    Count = m.Count,
                    DiscountRate = m.DiscountRate,
                    OrderId = m.OrderId,
                    ProductId = m.ProductId,
                    UnitPrice = m.UnitPrice
                }).ToList()
            }).OrderByDescending(x=>x.OrderId).ToList();

            query.ForEach(order =>order.AccountName = account.FirstOrDefault(x=>x.Id == order.AccountId)?.FullName);
            query.ForEach(order => order.PaymentMethod = PaymentMethod.GetBy(order.PaymentMethodId).Name);

            return query;
        }

        public List<OrderViewModel> Search(OrderSearchModel searchModel)
        {
            var account = _accountContext.Accounts.Select(x => new
            {
                x.FullName,
                x.Id
            }).ToList();
            var query = _shopContext.Orders.Where(x=>x.AccountId == searchModel.AccountId).Select(x => new OrderViewModel
            {
                IssueTrackingNo = x.IssueTrackingNo,
                DiscountAmount = x.DiscountAmount,
                RefId = x.RefId,
                TotalAmount = x.TotalAmount,
                PaymentMethodId = x.PaymentMethod,
                IsPaid = x.IsPaid,
                IsCanceled = x.IsCanceled,
                PayAmount = x.PayAmount,
                AccountId = x.AccountId,
                DateTime = x.CreationDate.ToFarsi(),
                OrderId = x.Id,
    
            }).OrderByDescending(x => x.OrderId).ToList();

            query.ForEach(order => order.AccountName = account.FirstOrDefault(x => x.Id == order.AccountId)?.FullName);
            query.ForEach(order => order.PaymentMethod = PaymentMethod.GetBy(order.PaymentMethodId).Name);

            return query;
        }

        public List<OrderItemViewModel> GetItemsBy(long id)
        {
            var orders = new List<OrderItemViewModel>();
            var products = _shopContext.Products.Select(x => new {x.Name, x.Id}).ToList();
            var orderItems = _shopContext.Orders.Where(x=>x.Id == id).Select(x=>x.Items.Select(m=>new OrderItemViewModel
            {
                Count = m.Count,
                DiscountRate = m.DiscountRate,
                OrderId = m.OrderId,
                ProductId = m.ProductId,
                UnitPrice = m.UnitPrice
            })).ToList();

            foreach (var orderItem in orderItems)
            {
                orders.AddRange(orderItem.Select(items => new OrderItemViewModel()
                {
                    Count = items.Count,
                    DiscountRate = items.DiscountRate,
                    OrderId = items.OrderId,
                    ProductId = items.ProductId,
                    UnitPrice = items.UnitPrice
                }));
            }

            orders.ForEach(x=>x.ProductName = products.FirstOrDefault(m=>m.Id == x.ProductId)?.Name);
      

            return orders;
        }
   }
}
