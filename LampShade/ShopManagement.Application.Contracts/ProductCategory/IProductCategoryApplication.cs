using System.Collections.Generic;
using _0_FrameWork.Application;

namespace ShopManagement.Application.Contracts.ProductCategory
{
    public interface IProductCategoryApplication
    {
        OperationResult Create(CreateProductCategory command);
        OperationResult Edit(EditProductCategory command);
        EditProductCategory GetDetails(long id);
        List<ProductCategorySearchViewModel> Search(ProductCategorySearchModel searchModel);
        List<ProductCategorySearchViewModel> Search();
    }
}