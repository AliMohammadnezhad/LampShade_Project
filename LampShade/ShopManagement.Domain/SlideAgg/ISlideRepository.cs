using System.Collections.Generic;
using _0_FrameWork.Domain;
using ShopManagement.Application.Contracts.Slide;

namespace ShopManagement.Domain.SlideAgg
{
    public interface ISlideRepository : IRepository<long, Slide>
    {
        List<SlideViewModel> GetList();
        EditSlide GetDetails(long id);
    }
}
