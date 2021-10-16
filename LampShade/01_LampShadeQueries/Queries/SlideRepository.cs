using System.Collections.Generic;
using System.Linq;
using _01_LampShadeQueries.Contracts.Slide;
using ShopManagement.Infrastructure.EFCore;

namespace _01_LampShadeQueries.Queries
{
   public class SlideRepository:ISlideRepository
   {
       private readonly ShopContext _context;

       public SlideRepository(ShopContext context)
       {
           _context = context;
       }
       public List<SlideViewModel> GetSlides()
       {
           return _context.Slides.Where(x => x.IsRemoved == false).OrderByDescending(x=>x.Id).Select(x => new SlideViewModel
           {
               BtnText = x.BtnText,
               Heading = x.Heading,
               Link = x.Link,
               Picture = x.Picture,
               Title = x.Title,
               PictureAlt = x.PictureAlt,
               PictureTitle = x.PictureTitle,
               Text = x.Text
           }).ToList();
       }
    }
}
