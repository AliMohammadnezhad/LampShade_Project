using System.Collections.Generic;
using _01_LampShadeQueries.Contracts.ArticleCategory;
using _01_LampShadeQueries.Contracts.ProductCategory;

namespace _01_LampShadeQueries.Contracts.Menu
{
    public class MenuQueryModel
    {
        public List<ProductCategoryQueryModel> ProductCategories { get; set; }
        public List<ArticleCategoryQueryModel> ArticleCategories { get; set; }
    }
}
