using System.Threading.Tasks;
using _01_LampShadeQueries.Contracts.ArticleCategory;
using _01_LampShadeQueries.Contracts.Menu;
using _01_LampShadeQueries.Contracts.ProductCategory;
using Microsoft.AspNetCore.Mvc;

namespace ServiceHost.ViewComponents
{
    public class MenuViewComponent:ViewComponent
    {
        private readonly IProductCategoryQuery _productCategoryQuery;
        private readonly IArticleCategoryQuery _articleCategoryQuery;

        public MenuViewComponent(IArticleCategoryQuery articleCategoryQuery, IProductCategoryQuery productCategoryQuery)
        {
            _articleCategoryQuery = articleCategoryQuery;
            _productCategoryQuery = productCategoryQuery;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var menu = new MenuQueryModel
            {
                ArticleCategories = _articleCategoryQuery.GetCategories(),
                ProductCategories = _productCategoryQuery.GetProductCategories()
            };
            return await Task.FromResult(View(menu));
        }
    }
}
