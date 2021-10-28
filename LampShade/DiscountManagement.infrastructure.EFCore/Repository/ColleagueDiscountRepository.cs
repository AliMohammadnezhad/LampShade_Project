using System.Collections.Generic;
using System.Linq;
using _0_FrameWork.Infrastructure;
using DiscountManagement.Application.Contract.ColleagueDiscount;
using DiscountManagement.Domain.ColleagueDiscountAgg;
using Microsoft.EntityFrameworkCore;
using ShopManagement.Infrastructure.EFCore;

namespace DiscountManagement.infrastructure.EFCore.Repository
{
   public class ColleagueDiscountRepository:RepositoryBase<long,ColleagueDiscount>,IColleagueDiscountRepository
   {
       private readonly DiscountContext _context;
       private readonly ShopContext _shopContext;
        public ColleagueDiscountRepository(DiscountContext context,ShopContext shopContext) : base(context)
        {
            _context = context;
            _shopContext = shopContext;
        }

        public EditColleagueDiscount GetDetails(long id)
        {
            return _context.ColleagueDiscounts.Select(x => new EditColleagueDiscount
            {
                DiscountRate = x.DiscountRate,
                Id = x.Id,
                ProductId = x.ProductId
            }).FirstOrDefault(x => x.Id == id);
        }

        public List<ColleagueDiscountViewModel> Search()
        {
            var products = _shopContext.Products.Select(x => new {x.Id, x.Name}).ToList();
            var query = _context.ColleagueDiscounts.Select(x => new ColleagueDiscountViewModel
            {
                CreationDate = x.CreationDate.ToString(),
                DiscountRate = x.DiscountRate,
                Id = x.Id,
                ProductId = x.ProductId
            }).OrderByDescending(x=>x.CreationDate).ToList();

            query.ForEach(discount=>discount.Product = products.FirstOrDefault(x=>x.Id == discount.ProductId)?.Name);
            return query;
        }

        public List<ColleagueDiscountViewModel> Search(ColleagueDiscountSearchModel command)
        {
            var products = _shopContext.Products.Select(x => new {x.Id, x.Name}).ToList();
            var query = _context.ColleagueDiscounts.Select(x => new ColleagueDiscountViewModel
            {
                CreationDate = x.CreationDate.ToString(),
                DiscountRate = x.DiscountRate,
                Id = x.Id,
                ProductId = x.ProductId
            }).OrderByDescending(x => x.CreationDate).ToList();

            query.ForEach(discount=>discount.Product = products.FirstOrDefault(x=>x.Id == discount.ProductId)?.Name);
            return query;
        }
    }
}
