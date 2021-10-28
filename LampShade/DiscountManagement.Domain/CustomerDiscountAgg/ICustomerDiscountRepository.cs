using System.Collections.Generic;
using _0_FrameWork.Domain;
using DiscountManagement.Application.Contract.CustomerDiscount;

namespace DiscountManagement.Domain.CustomerDiscountAgg
{
    public  interface ICustomerDiscountRepository:IRepository<long,CustomerDiscount>
    {
        EditCustomerDiscount GetDetails(long id);
        List<CustomerDiscountViewModel> Search();
        List<CustomerDiscountViewModel> Search(CustomerDiscountSearchModel searchModel);
    }
}
