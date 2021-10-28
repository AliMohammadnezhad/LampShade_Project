using DiscountManagement.Application.ColleagueDiscountApplication;
using DiscountManagement.Application.Contract.ColleagueDiscount;
using DiscountManagement.Application.Contract.CustomerDiscount;
using DiscountManagement.Application.CustomerDiscount;
using DiscountManagement.Domain.ColleagueDiscountAgg;
using DiscountManagement.Domain.CustomerDiscountAgg;
using DiscountManagement.infrastructure.EFCore;
using DiscountManagement.infrastructure.EFCore.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace DiscountManagement.Configuration
{
    public class DiscountManagementBootstrapper
    {
        public static void Configure(IServiceCollection service, string connectionString)
        {
            service.AddTransient<ICustomerDiscountApplication, CustomerDiscountApplication>();
            service.AddTransient<ICustomerDiscountRepository,CustomerDiscountRepository>();

            service.AddTransient<IColleagueDiscountApplication, ColleagueDiscountApplication>();
            service.AddTransient<IColleagueDiscountRepository, ColleagueDiscountRepository>();

            service.AddDbContext<DiscountContext>(x=>x.UseSqlServer(connectionString));
        }
    }
}
