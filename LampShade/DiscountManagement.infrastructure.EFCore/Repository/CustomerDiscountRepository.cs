using System.Collections.Generic;
using System.Linq;
using _0_Framework.Application;
using _0_FrameWork.Infrastructure;
using DiscountManagement.Application.Contract.CustomerDiscount;
using DiscountManagement.Domain.CustomerDiscountAgg;
using ShopManagement.Infrastructure.EFCore;

namespace DiscountManagement.infrastructure.EFCore.Repository
{
    public class CustomerDiscountRepository : RepositoryBase<long, CustomerDiscount>, ICustomerDiscountRepository
    {
        private readonly DiscountContext _context;
        private readonly ShopContext _shopContext;
        public CustomerDiscountRepository(DiscountContext context,ShopContext shopContext) : base(context)
        {
            _context = context;
            _shopContext = shopContext;
        }

        public EditCustomerDiscount GetDetails(long id)
        {
            return _context.CustomerDiscounts.Select(x => new EditCustomerDiscount
            {
                DiscountRate = x.DiscountRate,
                EndDate = x.EndDate.ToFarsi(),
                Id = x.Id,
                ProductId = x.ProductId,
                Reason = x.Reason,
                StartDate = x.StartDate.ToFarsi()
            }).FirstOrDefault(x => x.Id == id);
        }

        public List<CustomerDiscountViewModel> Search()
        {
            var products = _shopContext.Products.Select(x=>new {x.Id,x.Name}).ToList();
            var customerDiscountViewModels = _context.CustomerDiscounts.Select(x=>new CustomerDiscountViewModel
            {
                ProductId = x.ProductId,
                Reason = x.Reason,
                StartDate = x.StartDate.ToFarsi(),
                DiscountRate = x.DiscountRate,
                EndDate = x.EndDate.ToFarsi(),
                Id = x.Id,
                CreationDate = x.CreationDate.ToFarsi()
            }).ToList();

            customerDiscountViewModels.ForEach(discount=> discount.Product = products.FirstOrDefault(x=>x.Id == discount.ProductId)?.Name);
            return customerDiscountViewModels;
        }

        public List<CustomerDiscountViewModel> Search(CustomerDiscountSearchModel searchModel)
        {
            var products = _shopContext.Products.Select(x => new {x.Id, x.Name}).ToList();
            var customerDiscountViewModel = _context.CustomerDiscounts.Select(x => new CustomerDiscountViewModel
            {
                DiscountRate = x.DiscountRate,
                EndDate = x.EndDate.ToFarsi(),
                ProductId = x.ProductId,
                Reason = x.Reason,
                StartDate = x.StartDate.ToFarsi(),
                Id = x.Id,
                CreationDate = x.CreationDate.ToFarsi()
            }).ToList();

            customerDiscountViewModel = customerDiscountViewModel.Where(x =>
                x.ProductId == searchModel.ProductId ||
                x.StartDate.ToGeorgianDateTime() > searchModel.StartDate.ToGeorgianDateTime() ||
                x.EndDate.ToGeorgianDateTime() < searchModel.EndDate.ToGeorgianDateTime()).ToList();

            customerDiscountViewModel.ForEach(discount=> discount.Product = products.FirstOrDefault(x=>x.Id == discount.ProductId)?.Name);

            return customerDiscountViewModel;

        }
    }
}
