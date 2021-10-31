using System.Collections.Generic;
using _01_LampShadeQueries.Contracts.Product;

namespace _01_LampShadeQueries.Contracts.ProductCategory
{
    public class ProductCategoryQueryModel
    {

        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Picture { get; set; }
        public string PictureAlt { get; set; }
        public string PictureTitle { get; set; }
        public string Slug { get; set; }
        public List<ProductQueryModel> Products { get; set; }
    }
}
