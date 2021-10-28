using System.Threading.Tasks;
using _01_LampShadeQueries.Contracts.ProductCategory;
using Microsoft.AspNetCore.Mvc;

namespace ServiceHost.ViewComponents
{
    public class ProductCategoryViewComponent:ViewComponent
    {
        private readonly IProductCategoryQuery _productCategoryQuery;

        public ProductCategoryViewComponent(IProductCategoryQuery productCategoryQuery)
        {
            _productCategoryQuery = productCategoryQuery;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var productCategoryForMainPage = _productCategoryQuery.GetProductCategoryForMainPage();
            return await Task.FromResult(View(productCategoryForMainPage));
        }
    }
}
