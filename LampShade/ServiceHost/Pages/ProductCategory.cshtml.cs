using _01_LampShadeQueries.Contracts.ProductCategory;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ServiceHost.Pages
{
   
    public class ProductCategoryModel : PageModel
    {
        public ProductCategoryQueryModel CategoryQueryModel;
        private readonly IProductCategoryQuery _productCategory;

        public ProductCategoryModel(IProductCategoryQuery productCategory)
        {
            _productCategory = productCategory;
        }
        public void OnGet(string id)
        {
           CategoryQueryModel =  _productCategory.GetProductCategoryWithProductsBy(id);
        }
    }
}
