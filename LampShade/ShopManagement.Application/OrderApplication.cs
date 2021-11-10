using System;
using System.Collections.Generic;
using System.Linq;
using _0_Framework.Application;
using _0_FrameWork.Application.Sms;
using AccountManagement.Application.Contract.Address;
using Microsoft.Extensions.Configuration;
using ShopManagement.Application.Contracts.Order;
using ShopManagement.Domain.OrderAgg;
using ShopManagement.Domain.Service;

namespace ShopManagement.Application
{
    public class OrderApplication:IOrderApplication
    {
        private readonly ISmsSender _sender;
        private readonly IShopAccountAcl _accountAcl;
        private readonly IConfiguration _configuration;
        private readonly IShopInventoryAcl _shopInventory;
        private readonly IOrderRepository _orderRepository;
        private readonly IAddressApplication _addressApplication;

        public OrderApplication(IOrderRepository orderRepository,  IConfiguration configuration, IShopInventoryAcl shopInventory, IShopAccountAcl accountAcl, ISmsSender sender, IAddressApplication addressApplication)
        {
            _orderRepository = orderRepository;
            _configuration = configuration;
            _shopInventory = shopInventory;
            _accountAcl = accountAcl;
            _sender = sender;
            _addressApplication = addressApplication;
        }


        public long PlaceOrder(Cart cart,long userId)
        {
            var address = _addressApplication.GetAddressByUser(userId);
            var order = new Order(userId, cart.PaymentMethod,cart.TotalAmount, cart.DiscountAmount, cart.CartForPayAmount,address);

            foreach (var orderItem in cart.CartItems.Select(cartItem =>
                new OrderItem(cartItem.Id, cartItem.Count, cartItem.UnitPrice,cartItem.DiscountRate.Value)))
            {
                order.AddItem(orderItem);
            }

            _orderRepository.Create(order);
            _orderRepository.SaveChange();
            return order.Id;

        }

        public string PaymentSucceeded(long orderId, long refId)
        {
            var order = _orderRepository.Get(orderId);
            order.PaymentSucceeded(refId);
            var symbol = _configuration["Symbol"];
            var issueTrackingNo = CodeGenerator.Generate(symbol);
            order.SetIssueTrackingNo(issueTrackingNo);
            if (!_shopInventory.ReduceFromInventory(order.Items)) return null;
            _orderRepository.SaveChange();
            var (fullName, mobile) = _accountAcl.GetAccountForSendSmsBy(order.AccountId);
            var message = $"{fullName}گرامی سفارش شما با شماره پیگیری {issueTrackingNo} ثبت و درحال پیگیری می باشد باتشکر از شما ";
            _sender.SendSms(message,mobile);
            return issueTrackingNo;

        }

        public double GetOrderPriceBy(long id)
        {
            return _orderRepository.GetOrderPriceBy(id);
        }

        public List<OrderViewModel> Search(OrderSearchModel searchModel)
        {
            if (searchModel.AccountId > 0)
                return _orderRepository.Search(searchModel);
            return _orderRepository.Search();
        }

        public List<OrderItemViewModel> GetOrderItemsBy(long id)
        {
            return _orderRepository.GetItemsBy(id);
        }

        public List<OrderViewModel> GateLatestOrders()
        {
            return _orderRepository.GetLatestOrders();
        }

        public void Cancel(long id)
        {
            var order = _orderRepository.Get(id);
            order.Cancel();
            _orderRepository.SaveChange();
        }

        public (double DiscountSales, double Sales) CalculateOrdersSales()
        {
            return _orderRepository.CalculateOrdersSales();
        }

        public List<SalesInMothViewModel> GetSalesInMoth()
        {
            var salesInMoths = new List<SalesInMothViewModel>();
            var orders = _orderRepository.GetSalesInMoth();
            var months = new List<int>() {1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12};
         
            foreach (var month in months)
            {
                var item = new SalesInMothViewModel
                {
                    Count = orders.Count(x => x.CreationDateTime.GetFarsiMoth() == month),
                    PayAmount = orders.Where(x => x.CreationDateTime.GetFarsiMoth() == month).Sum(x => x.PayAmount)
                    
                };
                salesInMoths.Add(item);
             
            }

            return salesInMoths;
        }

        public double GetAllOrdersCount()
        {
            return _orderRepository.GetAllOrderCount();
        }

        public OrderViewModel GetOrderBy(long accountId, string issueTrackingNumber)
        {
            return _orderRepository.GetOrderBy(accountId, issueTrackingNumber);
        }

        public OrderViewModel GetOrderAddressByOrder(long id)
        {
            return _orderRepository.GetOrderAddressByOrder(id);
        }
    }
}
