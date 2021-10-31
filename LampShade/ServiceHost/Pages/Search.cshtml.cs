using System.Collections.Generic;
using _01_LampShadeQueries.Contracts.Product;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ServiceHost.Pages
{
    public class SearchModel : PageModel
    {
        public string Query;
        public List<ProductQueryModel> Products;

        private readonly IProductQuery _productQuery;

        public SearchModel(IProductQuery productQuery)
        {
            _productQuery = productQuery;
        }
        public void OnGet(string p)
        {
            Query = p;
            Products = _productQuery.Search(p);
        }
    }
}
