using System.Collections.Generic;
using _0_FrameWork.Application;

namespace ShopManagement.Application.Contracts.Slide
{
    public interface ISlideApplication
    {
        OperationResult Create(CreateSlide command);
        OperationResult Edit(EditSlide command);
        OperationResult Restore(long id);
        OperationResult Remove(long id);
        EditSlide GetDetails(long id);
        List<SlideViewModel> GetList();
    }
}
