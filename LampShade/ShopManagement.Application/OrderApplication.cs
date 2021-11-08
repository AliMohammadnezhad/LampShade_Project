using System.Collections.Generic;
using System.Linq;
using _0_Framework.Application;
using _0_FrameWork.Application.Sms;
using Microsoft.Extensions.Configuration;
using ShopManagement.Application.Contracts.Order;
using ShopManagement.Domain.OrderAgg;
using ShopManagement.Domain.Service;

namespace ShopManagement.Application
{
    public class OrderApplication:IOrderApplication
    {
        private readonly IShopInventoryAcl _shopInventory;
        private readonly IOrderRepository _orderRepository;
        private readonly IConfiguration _configuration;
        private readonly IShopAccountAcl _accountAcl;
        private readonly ISmsSender _sender;
        public OrderApplication(IOrderRepository orderRepository,  IConfiguration configuration, IShopInventoryAcl shopInventory, IShopAccountAcl accountAcl, ISmsSender sender)
        {
            _orderRepository = orderRepository;
            _configuration = configuration;
            _shopInventory = shopInventory;
            _accountAcl = accountAcl;
            _sender = sender;
        }


        public long PlaceOrder(Cart cart,long userId)
        {
            var order = new Order(userId, cart.PaymentMethod,cart.TotalAmount, cart.DiscountAmount, cart.CartForPayAmount);

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

        public void Cancel(long id)
        {
            var order = _orderRepository.Get(id);
            order.Cancel();
            _orderRepository.SaveChange();
        }
    }
}
