using System.Threading.Tasks;
using _01_LampShadeQueries.Contracts.Product;
using Microsoft.AspNetCore.Mvc;

namespace ServiceHost.ViewComponents
{
    public class LatestProductsViewComponent:ViewComponent
    {
        private readonly IProductQuery _productQuery;

        public LatestProductsViewComponent(IProductQuery productQuery)
        {
            _productQuery = productQuery;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var products = _productQuery.GetLatestProducts();
            return await Task.FromResult(View(products));
        }
    }
}
