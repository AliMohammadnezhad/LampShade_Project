using System.Collections.Generic;
using System.Linq;
using _01_LampShadeQueries.Contracts.ProductCategory;
using ShopManagement.Infrastructure.EFCore;

namespace _01_LampShadeQueries.Queries
{
    public class ProductCategoryQuery : IProductCategoryQuery
    {
        private readonly ShopContext _context;

        public ProductCategoryQuery(ShopContext context)
        {
            _context = context;
        }
        public List<ProductCategoryQueryModel> GetProductCategoryForMainPage()
        {
            return _context.ProductCategories.Where(x=>x.IsRemoved == false).OrderByDescending(x => x.Id).Take(3).Select(x =>
                new ProductCategoryQueryModel
                {
                    Description = x.Description,
                    Name = x.Name,
                    Picture = x.Picture,
                    PictureAlt = x.PictureAlt,
                    PictureTitle = x.PictureTitle,
                    Slug = x.Slug
                }).ToList();
        }
    }
}
