using System.Collections.Generic;
using _0_FrameWork.Domain;
using DiscountManagement.Application.Contract.ColleagueDiscount;

namespace DiscountManagement.Domain.ColleagueDiscountAgg
{
    public interface IColleagueDiscountRepository:IRepository<long,ColleagueDiscount>
    {
        EditColleagueDiscount GetDetails(long id);
        List<ColleagueDiscountViewModel> Search();
        List<ColleagueDiscountViewModel> Search(ColleagueDiscountSearchModel command);
    }
}
