using System.Threading.Tasks;
using _01_LampShadeQueries.Contracts.Slide;
using Microsoft.AspNetCore.Mvc;

namespace ServiceHost.ViewComponents
{
    public class SlideViewComponent:ViewComponent
    {
        private readonly ISlideQuery _slideQuery;

        public SlideViewComponent(ISlideQuery slideQuery)
        {
            _slideQuery = slideQuery;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var slides = _slideQuery.GetSlides();
            return await Task.FromResult(View(slides));
        }
    }
}
