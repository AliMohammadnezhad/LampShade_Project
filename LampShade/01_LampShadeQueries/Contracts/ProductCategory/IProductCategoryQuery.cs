using System.Collections.Generic;

namespace _01_LampShadeQueries.Contracts.ProductCategory
{
    public interface IProductCategoryQuery
    {
        ProductCategoryQueryModel GetProductCategoryWithProductsBy(string slug);
        List<ProductCategoryQueryModel> GetProductCategoryForMainPage();
        List<ProductCategoryQueryModel> GetProductCategoryWithProducts();
    }
}