using System.Collections.Generic;

namespace ShopManagement.Application.Contracts.Order
{
    public interface IOrderApplication
    {
        long PlaceOrder(Cart cart,long userId);
        string PaymentSucceeded(long orderId, long refId);
        double GetOrderPriceBy(long id);
        List<OrderViewModel> Search(OrderSearchModel searchModel);
        List<OrderItemViewModel> GetOrderItemsBy(long id);
        List<OrderViewModel> GateLatestOrders();
        void Cancel(long id);
        (double DiscountSales, double Sales) CalculateOrdersSales();
        List<SalesInMothViewModel> GetSalesInMoth();
        double GetAllOrdersCount();
        OrderViewModel GetOrderBy(long accountId, string issueTrackingNumber);

    }
}
