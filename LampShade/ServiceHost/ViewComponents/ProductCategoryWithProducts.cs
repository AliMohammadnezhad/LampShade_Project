using System.Threading.Tasks;
using _01_LampShadeQueries.Contracts.ProductCategory;
using Microsoft.AspNetCore.Mvc;

namespace ServiceHost.ViewComponents
{
    public class ProductCategoryWithProducts:ViewComponent
    {
        private readonly IProductCategoryQuery _productCategoryQuery;

        public ProductCategoryWithProducts(IProductCategoryQuery productCategoryQuery)
        {
            _productCategoryQuery = productCategoryQuery;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var categoryWithProducts = _productCategoryQuery.GetProductCategoryWithProducts();
            return await Task.FromResult(View(categoryWithProducts));
        }
    }
}
