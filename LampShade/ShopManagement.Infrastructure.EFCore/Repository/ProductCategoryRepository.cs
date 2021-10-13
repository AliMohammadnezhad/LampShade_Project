using System.Collections.Generic;
using System.Linq;
using _0_FrameWork.Infrastructure;
using ShopManagement.Application.Contracts.ProductCategory;
using ShopManagement.Domain.ProductCategoryAgg;

namespace ShopManagement.Infrastructure.EFCore.Repository
{
    public class ProductCategoryRepository : RepositoryBase<long, ProductCategory>, IProductCategoryRepository
    {
        private readonly ShopContext _context;

        public ProductCategoryRepository(ShopContext context) : base(context)
        {
            _context = context;
        }

        public EditProductCategory GetDetails(long id)
        {
            return _context.ProductCategories.Select(x => new EditProductCategory
            {
                Name = x.Name,
                Picture = x.Picture,
                Description = x.Description,
                PictureTitle = x.PictureTitle,
                Keywords = x.Keywords,
                MetaDescription = x.MetaDescription,
                Slug = x.Slug,
                PictureAlt = x.PictureAlt,
                Id = x.Id
            }).FirstOrDefault(x => x.Id == id);
        }

        public List<ProductCategorySearchViewModel> Search(ProductCategorySearchModel searchModel)
        {
            var query = _context.ProductCategories.Select(x => new ProductCategorySearchViewModel
            {
                Id = x.Id,
                CreationDate = x.CreationDate.ToString(),
                Description = x.Description,
                Name = x.Name,
                Picture = x.Picture
            });
            if (!string.IsNullOrWhiteSpace(searchModel.Name)) query.Where(x => x.Name.Contains(searchModel.Name));
            return query.ToList();
        }
    }
}