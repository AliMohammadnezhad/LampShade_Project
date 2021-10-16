using System.Threading.Tasks;
using _01_LampShadeQueries.Contracts.Slide;
using Microsoft.AspNetCore.Mvc;

namespace ServiceHost.ViewComponents
{
    public class SlideViewComponent:ViewComponent
    {
        private readonly ISlideRepository _slideRepository;

        public SlideViewComponent(ISlideRepository slideRepository)
        {
            _slideRepository = slideRepository;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var slides = _slideRepository.GetSlides();
            return await Task.FromResult(View(slides));
        }
    }
}
