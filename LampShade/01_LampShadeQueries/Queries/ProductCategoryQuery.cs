using System;
using System.Collections.Generic;
using System.Linq;
using _0_Framework.Application;
using _01_LampShadeQueries.Contracts.Product;
using _01_LampShadeQueries.Contracts.ProductCategory;
using DiscountManagement.infrastructure.EFCore;
using InventoryManagement.Infrastructure.EfCore;
using Microsoft.EntityFrameworkCore;
using ShopManagement.Domain.ProductAgg;
using ShopManagement.Infrastructure.EFCore;

namespace _01_LampShadeQueries.Queries
{
    public class ProductCategoryQuery : IProductCategoryQuery
    {
        private readonly ShopContext _context;
        private readonly InventoryContext _inventoryContext;
        private readonly DiscountContext _discountContext;
        public ProductCategoryQuery(ShopContext context,InventoryContext inventory, DiscountContext discountContext)
        {
            _context = context;
            _inventoryContext = inventory;
            _discountContext = discountContext;
        }

        public ProductCategoryQueryModel GetProductCategoryWithProductsBy(string slug)
        {
            var productDiscount = _discountContext.CustomerDiscounts
                .Where(x => x.StartDate < DateTime.Now && x.EndDate > DateTime.Now)
                .Select(x => new {x.DiscountRate, x.ProductId, x.EndDate}).ToList();
            var productInventory = _inventoryContext.Inventory.Select(x => new {x.UnitPrice, x.ProductId}).ToList();
            var category = _context.ProductCategories.Include(x => x.Products).ThenInclude(x => x.Category).Select(x =>
                new ProductCategoryQueryModel
                {
                    Description = x.Description,
                    Id = x.Id,
                    Name = x.Name,
                    Picture = x.Picture,
                    PictureAlt = x.PictureAlt,
                    PictureTitle = x.PictureTitle,
                    Slug = x.Slug,
                    Products = MapProducts(x.Products)
                }).FirstOrDefault(x => x.Slug == slug);
            if (category != null)
                foreach (var product in category.Products)
                {
                    var price = productInventory.FirstOrDefault(x => x.ProductId == product.Id)?.UnitPrice;
                    var discountRate = productDiscount.FirstOrDefault(x => x.ProductId == product.Id)?.DiscountRate;
                    var discountEndDate = productDiscount.FirstOrDefault(x => x.ProductId == product.Id)?.EndDate;
                    product.HasDiscount = discountRate > 0;
                    product.Price = price?.ToMoney();
                    if (discountRate != null)
                    {
                        var priceWithDiscount = (price - ((price * discountRate) / 100))?.ToMoney();
                        product.DiscountRate = (int) discountRate;
                        product.PriceWithDiscount = priceWithDiscount;
                        if (discountEndDate != null) product.EndDate = discountEndDate.Value.ToDiscountFormat();
                    }
                }

            return category;
        }

        public List<ProductCategoryQueryModel> GetProductCategoryForMainPage()
        {
            return _context.ProductCategories.Where(x => x.IsRemoved == false).OrderByDescending(x => x.Id).Take(3)
                .Select(x => new ProductCategoryQueryModel
                {
                    Description = x.Description,
                    Name = x.Name,
                    Picture = x.Picture,
                    PictureAlt = x.PictureAlt,
                    PictureTitle = x.PictureTitle,
                    Slug = x.Slug
                }).ToList();
        }

        public List<ProductCategoryQueryModel> GetProductCategoryWithProducts()
        {
            var productDiscount = _discountContext.CustomerDiscounts
                .Where(x => x.StartDate < DateTime.Now && x.EndDate > DateTime.Now)
                .Select(x => new {x.DiscountRate, x.ProductId}).ToList();
            var productInventory = _inventoryContext.Inventory.Select(x => new {x.UnitPrice, x.ProductId}).ToList();
            var categories = _context.ProductCategories.Include(x => x.Products).ThenInclude(x => x.Category)
                .Select(x => new ProductCategoryQueryModel
                {
                    Id = x.Id, Name = x.Name, Products = MapProducts(x.Products)
                }).ToList();
            foreach (var product in categories.SelectMany(category => category.Products))
            {
                var price = productInventory.FirstOrDefault(x => x.ProductId == product.Id)?.UnitPrice;
                var discountRate = productDiscount.FirstOrDefault(x => x.ProductId == product.Id)?.DiscountRate;
                product.HasDiscount = discountRate > 0;
                product.Price = price?.ToMoney();
                if (discountRate != null)
                {
                    var priceWithDiscount = (price - ((price * discountRate) / 100))?.ToMoney();
                    product.DiscountRate = (int) discountRate;
                    product.PriceWithDiscount = priceWithDiscount;
                }
            }

            return categories;
        }

        private static List<ProductQueryModel> MapProducts(IEnumerable<Product> xProducts)
        {
            return xProducts.Select(product => new ProductQueryModel
            {
                Category = product.Category.Name,
                Id = product.Id,
                Name = product.Name,
                Picture = product.Picture,
                PictureAlt = product.PictureAlt,
                PictureTitle = product.PictureTitle,
                Slug = product.Slug,
            }).ToList();
        }
    }
}
