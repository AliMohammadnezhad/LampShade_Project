using System.Collections.Generic;
using _0_FrameWork.Domain;
using ShopManagement.Application.Contracts.Order;

namespace ShopManagement.Domain.OrderAgg
{
    public interface IOrderRepository:IRepository<long,Order>
    {
        double GetOrderPriceBy(long id);
        Order GetOrderBy(long userId);
        List<OrderViewModel> Search();
        List<OrderViewModel> GetLatestOrders();
        List<OrderViewModel> Search(OrderSearchModel searchModel);
        List<OrderItemViewModel> GetItemsBy(long id);
        (double DiscountSales, double Sales) CalculateOrdersSales();
        List<SalesInMothViewModel> GetSalesInMoth();
        double GetAllOrderCount();
        OrderViewModel GetOrderBy(long accountId, string issueTrackingNumber);
        OrderViewModel GetOrderAddressByOrder(long id);


    }
}
