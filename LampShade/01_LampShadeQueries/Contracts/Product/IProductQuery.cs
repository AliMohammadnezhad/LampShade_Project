using System.Collections.Generic;
using ShopManagement.Application.Contracts.Order;

namespace _01_LampShadeQueries.Contracts.Product
{
    public interface IProductQuery
    {
        ProductQueryModel GetProductDetails(string slug);
        List<ProductQueryModel> Search(string p);
        List<ProductQueryModel> GetLatestProducts();
        List<CartItem> CheckCartItemInventoryStatus(List<CartItem> cartItems);
    }
}
