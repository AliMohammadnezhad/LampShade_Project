using System.Collections.Generic;
using System.Linq;
using _0_Framework.Application;
using _0_FrameWork.Infrastructure;
using Microsoft.EntityFrameworkCore;
using ShopManagement.Application.Contracts.Product;
using ShopManagement.Domain.ProductAgg;

namespace ShopManagement.Infrastructure.EFCore.Repository
{
    public class ProductRepository : RepositoryBase<long, Product>, IProductRepository
    {
        private readonly ShopContext _context;

        public ProductRepository(ShopContext context) : base(context)
        {
            _context = context;
        }

        public EditProduct GetDetails(long id)
        {
            return _context.Products.Select(x => new EditProduct
            {
                CategoryId = x.CategoryId,
                Code = x.Code,
                Description = x.Description,
                Id = x.Id,
                KeyWords = x.KeyWords,
                MetaDescription = x.MetaDescription,
                Name = x.Name,
                Picture = x.Picture,
                ShortDescription = x.ShortDescription,
                Slug = x.Slug,
                PictureTitle = x.PictureTitle,
                PictureAlt = x.PictureAlt,
                UnitPrice = x.UnitPrice
            }).FirstOrDefault(x => x.Id == id);
        }

        public List<ProductViewModel> Search(ProductSearchModel searchModel)
        {
            return _context.Products
                .Include(p => p.Category).Where(x => x.Name.Contains(searchModel.Name) || x.Code == searchModel.Code ||
                                                     x.CategoryId == searchModel.CategoryId)
                .OrderByDescending(x => x.CreationDate).Select(x => new ProductViewModel
                {
                    UnitPrice = x.UnitPrice,
                    Category = x.Category.Name,
                    Name = x.Name,
                    Code = x.Code,
                    Id = x.Id,
                    Picture = x.Picture,
                    CreationDate = x.CreationDate.ToFarsi(),
                    StockStatus = x.IsInStock
                }).OrderByDescending(x=>x.Id).ToList();
        }

        public List<ProductViewModel> Search()
        {
            return _context.Products.Include(p => p.Category).OrderByDescending(x => x.CreationDate).Select(x =>
                new ProductViewModel
                {
                    UnitPrice = x.UnitPrice,
                    Category = x.Category.Name,
                    Name = x.Name,
                    Code = x.Code,
                    Id = x.Id,
                    Picture = x.Picture,
                    CreationDate = x.CreationDate.ToFarsi(),
                    StockStatus = x.IsInStock
                }).OrderByDescending(x => x.Id).ToList();
        }

        public List<ProductViewModel> GetProducts()
        {
            return _context.Products.Select(x => new ProductViewModel
            {
                Id = x.Id,
                Name = x.Name
            }).ToList();
        }
    }
}