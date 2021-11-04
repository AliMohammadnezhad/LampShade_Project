using DiscountManagement.Application.Contract.ColleagueDiscount;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShopManagement.Application.Contracts.Product;
using System.Collections.Generic;
using _0_FrameWork.Infrastructure;
using DiscountManagement.Configuration.Permission;

namespace ServiceHost.Areas.Administration.Pages.Discounts.ColleagueDiscounts
{
    
    public class IndexModel : PageModel
    {
        [TempData]
        public string Message { get; set; }
        public ColleagueDiscountSearchModel SearchModel;
        public List<ColleagueDiscountViewModel> ColleagueDiscounts;
        public SelectList Products;

        private readonly IProductApplication _productApplication;
        private readonly IColleagueDiscountApplication _colleagueDiscountApplication;

        public IndexModel(IProductApplication ProductApplication, IColleagueDiscountApplication colleagueDiscountApplication)
        {
            _productApplication = ProductApplication;
            _colleagueDiscountApplication = colleagueDiscountApplication;
        }

        [NeedsPermission(DiscountPermission.SearchColleagueDiscount)]
        public void OnGet(ColleagueDiscountSearchModel searchModel)
        {
            Products = new SelectList(_productApplication.GetProducts(), "Id", "Name");
            ColleagueDiscounts = _colleagueDiscountApplication.Search(searchModel);
        }
        [NeedsPermission(DiscountPermission.DefineColleagueDiscount)]
        public IActionResult OnGetCreate()
        {
            var command = new DefineColleagueDiscount
            {
                Products = _productApplication.GetProducts()
            };
            return Partial("./Create", command);
        }
        [NeedsPermission(DiscountPermission.DefineColleagueDiscount)]
        public JsonResult OnPostCreate(DefineColleagueDiscount command)
        {
            var result = _colleagueDiscountApplication.Define(command);
            return new JsonResult(result);
        }
        [NeedsPermission(DiscountPermission.EditColleagueDiscount)]
        public IActionResult OnGetEdit(long id)
        {
            var colleagueDiscount = _colleagueDiscountApplication.GetDetails(id);
            colleagueDiscount.Products = _productApplication.GetProducts();
            return Partial("Edit", colleagueDiscount);
        }
        [NeedsPermission(DiscountPermission.EditColleagueDiscount)]
        public JsonResult OnPostEdit(EditColleagueDiscount command)
        {
            var result = _colleagueDiscountApplication.Edit(command);
            return new JsonResult(result);
        }
        [NeedsPermission(DiscountPermission.RemoveColleagueDiscount)]
        public IActionResult OnGetRemove(long id)
        {
            _colleagueDiscountApplication.Remove(id);
            return RedirectToPage("./Index");
        }
        [NeedsPermission(DiscountPermission.RestoreColleagueDiscount)]
        public IActionResult OnGetRestore(long id)
        {
            _colleagueDiscountApplication.Restore(id);
            return RedirectToPage("./Index");
        }
    }
}
