using System.Collections.Generic;
using _0_FrameWork.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShopManagement.Application.Contracts.Slide;
using ShopManagement.Configuration.Permissions;

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
        [NeedsPermission(ShopPermissions.ListSlide)]
        public void OnGet()
        {
            Slides = _slideApplication.GetList();
        }

        [NeedsPermission(ShopPermissions.CreateSlide)]
        public IActionResult OnGetCreate()
        {

            return Partial("Create", new CreateSlide());
        }

        [NeedsPermission(ShopPermissions.CreateSlide)]
        public JsonResult OnPostCreate(CreateSlide command)
        {
            var operationResult = _slideApplication.Create(command);

            return new JsonResult(operationResult);
        }

        [NeedsPermission(ShopPermissions.EditSlide)]
        public IActionResult OnGetEdit(long id)
        {
            var slide = _slideApplication.GetDetails(id);

            return Partial("Edit", slide);
        }

        [NeedsPermission(ShopPermissions.EditSlide)]
        public JsonResult OnPostEdit(EditSlide command)
        {
            var operationResult = _slideApplication.Edit(command);
            return new JsonResult(operationResult);
        }

        [NeedsPermission(ShopPermissions.RemoveSlide)]
        public JsonResult OnGetRemove(long id)
        {
            var isInStock = _slideApplication.Remove(id);
            return isInStock.IsSucceed ? new JsonResult(isInStock.Succeed()) : new JsonResult(isInStock);
        }

        [NeedsPermission(ShopPermissions.RestoreSlide)]
        public JsonResult OnGetRestore(long id)
        {
            var notInStock = _slideApplication.Restore(id);
            return notInStock.IsSucceed ? new JsonResult(notInStock.Succeed()) : new JsonResult(notInStock);
        }
    }
}