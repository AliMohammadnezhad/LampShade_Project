using System.Collections.Generic;

namespace _01_LampShadeQueries.Contracts.Product
{
    public interface IProductQuery
    {
        ProductQueryModel GetProductDetails(string slug);
        List<ProductQueryModel> Search(string p);
        List<ProductQueryModel> GetLatestProducts();
    }
}
