using System.Collections.Generic;

namespace _01_LampShadeQueries.Contracts.Slide
{
    public  interface ISlideRepository
    {
        List<SlideViewModel> GetSlides();
    }
}
