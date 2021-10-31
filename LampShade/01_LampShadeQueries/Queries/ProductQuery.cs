using System;
using System.Collections.Generic;
using System.Linq;
using _0_Framework.Application;
using _01_LampShadeQueries.Contracts.Product;
using DiscountManagement.infrastructure.EFCore;
using InventoryManagement.Infrastructure.EfCore;
using Microsoft.EntityFrameworkCore;
using ShopManagement.Infrastructure.EFCore;

namespace _01_LampShadeQueries.Queries
{
    public class ProductQuery : IProductQuery
    {
        private readonly ShopContext _shopContext;
        private readonly InventoryContext _inventoryContext;
        private readonly DiscountContext _discountContext;

        public ProductQuery(ShopContext shopContext, InventoryContext inventoryContext, DiscountContext discountContext)
        {
            _shopContext = shopContext;
            _inventoryContext = inventoryContext;
            _discountContext = discountContext;
        }

        public List<ProductQueryModel> Search(string p)
        {
            var inventory = _inventoryContext.Inventory.Select(x => new { x.UnitPrice, x.ProductId }).ToList();
            var productsDiscounts = _discountContext.CustomerDiscounts.Select(x => new { x.ProductId, x.DiscountRate,x.StartDate, x.EndDate })
                .ToList();

            var products = _shopContext.Products
                .Include(x => x.Category)
                .Where(x => x.Name.Contains(p) || x.Category.Name.Contains(p) || x.ShortDescription.Contains(p))
                .Select(x => new ProductQueryModel
                {
                    Category = x.Category.Name,
                    Id = x.Id,
                    Name = x.Name,
                    Picture = x.Picture,
                    PictureAlt = x.PictureAlt,
                    PictureTitle = x.PictureTitle,
                    Slug = x.Slug,
                }).ToList();

            foreach (var product in products)
            {
                var price = (from x in inventory where x.ProductId == product.Id select x.UnitPrice).FirstOrDefault();

                var discounts =
                    (from discount in productsDiscounts where discount.ProductId == product.Id && discount.StartDate <DateTime.Now && discount.EndDate>DateTime.Now select new {discount.DiscountRate,discount.EndDate})
                    .FirstOrDefault();
        

                if (price > 0) product.Price = price.ToMoney();
                if (discounts != null && discounts.DiscountRate > 0)
                {
                    product.HasDiscount = true;
                    product.DiscountRate = discounts.DiscountRate;
                    var priceWithDiscount = (price - ((price * discounts.DiscountRate) / 100)).ToMoney();

                    product.PriceWithDiscount = priceWithDiscount;
                    product.EndDate = discounts.EndDate.ToDiscountFormat();
                }

            }

            return products;
        }

        public List<ProductQueryModel> GetLatestProducts()
        {
            var inventory = _inventoryContext.Inventory.Select(x => new { x.ProductId, x.UnitPrice }).ToList();
            var discount = _discountContext.CustomerDiscounts
                .Where(x => x.StartDate < DateTime.Now && x.EndDate > DateTime.Now)
                .Select(x => new { x.DiscountRate, x.ProductId }).ToList();

            var products = _shopContext.Products.Include(x => x.Category).Select(x => new ProductQueryModel
            {
                Category = x.Category.Name,
                Slug = x.Slug,
                Id = x.Id,
                Name = x.Name,
                Picture = x.Picture,
                PictureAlt = x.PictureAlt,
                PictureTitle = x.PictureTitle,

            }).OrderByDescending(x => x.Id).Take(6).ToList();


            foreach (var product in products)
            {
                var price = inventory.FirstOrDefault(x => x.ProductId == product.Id)?.UnitPrice;
                var discountRate = discount.FirstOrDefault(x => x.ProductId == product.Id)?.DiscountRate;

                product.HasDiscount = discountRate > 0;
                product.Price = price?.ToMoney();
                if (discountRate != null)
                {
                    var priceWithDiscount = (price - ((price * discountRate) / 100))?.ToMoney();

                    product.DiscountRate = (int)discountRate;
                    product.PriceWithDiscount = priceWithDiscount;
                }
            }



            return products;
        }
    }
}
