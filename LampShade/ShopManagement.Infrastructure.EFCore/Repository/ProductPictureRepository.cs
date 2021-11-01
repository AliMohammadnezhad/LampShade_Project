using System.Collections.Generic;
using System.Linq;
using _0_Framework.Application;
using _0_FrameWork.Infrastructure;
using Microsoft.EntityFrameworkCore;
using ShopManagement.Application.Contracts.ProductPicture;
using ShopManagement.Domain.ProductPictureAgg;

namespace ShopManagement.Infrastructure.EFCore.Repository
{
    public class ProductPictureRepository : RepositoryBase<long, ProductPicture>, IProductPictureRepository
    {
        private readonly ShopContext _context;

        public ProductPictureRepository(ShopContext context) : base(context)
        {
            _context = context;
        }

        public EditProductPicture GetDetails(long id)
        {
            return _context.ProductPictures.Select(x => new EditProductPicture
            {
                Id = x.Id,
                PictureAlt = x.PictureAlt,
                PictureTitle = x.PictureTitle,
                ProductId = x.ProductId
            }).FirstOrDefault(x => x.Id == id);
        }

        public ProductPicture GetProductsPictureWithCategory(long id)
        {
            return _context.ProductPictures.Include(x => x.Product).ThenInclude(x => x.Category)
                .FirstOrDefault(x => x.Id == id);
        }

        public ProductPictureUploaderViewModel GetProductCategorySlugByProductId(long id)
        {
            return _context.Products.Include(x => x.Category).Where(x => x.Id == id)
                .Select(x => new ProductPictureUploaderViewModel
                {
                    ProductCategorySlug = x.Category.Slug,
                    ProductSlug = x.Slug
                }).FirstOrDefault();
        }

        public List<ProductPictureViewModel> Search()
        {
            return _context.ProductPictures.Include(x => x.Product).Select(x => new ProductPictureViewModel
            {
                CreationDate = x.CreationDate.ToFarsi(),
                Id = x.Id,
                Picture = x.Picture,
                Product = x.Product.Name,
                ProductId = x.Product.Id,
                IsRemoved = x.IsRemoved
            }).OrderByDescending(x => x.Id).ToList();
        }

        public List<ProductPictureViewModel> Search(ProductPictureSearchModel searchModel)
        {
            return _context.ProductPictures.Include(x => x.Product).Select(x => new ProductPictureViewModel
            {
                CreationDate = x.CreationDate.ToFarsi(),
                Id = x.Id,
                Picture = x.Picture,
                Product = x.Product.Name,
                ProductId = x.ProductId,
                IsRemoved = x.IsRemoved
            }).Where(x => x.ProductId == searchModel.ProductId).OrderByDescending(x => x.Id).ToList();
        }
    }
}
