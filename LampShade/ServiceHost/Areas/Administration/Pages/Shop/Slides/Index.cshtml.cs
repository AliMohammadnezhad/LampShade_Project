using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShopManagement.Application.Contracts.Product;
using ShopManagement.Application.Contracts.ProductCategory;
using ShopManagement.Application.Contracts.Slide;

namespace ServiceHost.Areas.Administration.Pages.Shop.Slides
{
    public class IndexModel : PageModel
    {
        private readonly ISlideApplication _slideApplication;
        public List<SlideViewModel> Slides;


        public IndexModel(ISlideApplication slideApplication)
        {
            _slideApplication = slideApplication;
        }

        public void OnGet()
        {
            Slides = _slideApplication.GetList();
        }

        public IActionResult OnGetCreate()
        {

            return Partial("Create", new CreateSlide());
        }

        public JsonResult OnPostCreate(CreateSlide command)
        {
            var operationResult = _slideApplication.Create(command);

            return new JsonResult(operationResult);
        }

        public IActionResult OnGetEdit(long id)
        {
            var slide = _slideApplication.GetDetails(id);

            return Partial("Edit", slide);
        }

        public JsonResult OnPostEdit(EditSlide command)
        {
            var operationResult = _slideApplication.Edit(command);
            return new JsonResult(operationResult);
        }

        public JsonResult OnGetRemove(long id)
        {
            var isInStock = _slideApplication.Remove(id);
            return isInStock.IsSucceed ? new JsonResult(isInStock.Succeed()) : new JsonResult(isInStock);
        }

        public JsonResult OnGetRestore(long id)
        {
            var notInStock = _slideApplication.Restore(id);
            return notInStock.IsSucceed ? new JsonResult(notInStock.Succeed()) : new JsonResult(notInStock);
        }
    }
}