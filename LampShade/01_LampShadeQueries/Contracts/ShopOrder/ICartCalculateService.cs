using System.Collections.Generic;
using ShopManagement.Application.Contracts.Order;

namespace _01_LampShadeQueries.Contracts.ShopOrder
{
    public interface ICartCalculateService
    {
        Cart ComputeCart(List<CartItem> cartItems);
    }
}
