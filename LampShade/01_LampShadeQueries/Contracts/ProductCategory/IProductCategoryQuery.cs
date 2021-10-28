using System.Collections.Generic;

namespace _01_LampShadeQueries.Contracts.ProductCategory
{
    public interface IProductCategoryQuery
    {
        List<ProductCategoryQueryModel> GetProductCategoryForMainPage();
    }
}