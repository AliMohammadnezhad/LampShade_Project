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
        List<OrderViewModel> Search(OrderSearchModel searchModel);
        List<OrderItemViewModel> GetItemsBy(long id);
    }
}
