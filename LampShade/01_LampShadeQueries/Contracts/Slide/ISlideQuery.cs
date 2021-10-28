using System.Collections.Generic;

namespace _01_LampShadeQueries.Contracts.Slide
{
    public  interface ISlideQuery
    {
        List<SlideQueryModel> GetSlides();
    }
}
