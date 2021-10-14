using System.Collections.Generic;
using _0_FrameWork.Domain;
using ShopManagement.Application.Contracts.ProductCategory;

namespace ShopManagement.Domain.ProductCategoryAgg
{
    public interface IProductCategoryRepository : IRepository<long, ProductCategory>
    {
        EditProductCategory GetDetails(long id);
        List<ProductCategorySearchViewModel> Search(ProductCategorySearchModel searchModel);
        List<ProductCategorySearchViewModel> Search();
    }
}