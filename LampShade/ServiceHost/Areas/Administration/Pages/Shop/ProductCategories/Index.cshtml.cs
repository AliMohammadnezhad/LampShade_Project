using System.Collections.Generic;
using System.Linq;
using _0_FrameWork.Application;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShopManagement.Application.Contracts.ProductCategory;

namespace ServiceHost.Areas.Administration.Pages.Shop.ProductCategories
{
    public class IndexModel : PageModel
    {
        private readonly IProductCategoryApplication _productCategoryApplication;
        public ProductCategoryViewModel Model;

        public List<ProductCategoryViewModel> ProductCategories;

        public IndexModel(IProductCategoryApplication productCategoryApplication)
        {
            _productCategoryApplication = productCategoryApplication;
        }

        public void OnGet(ProductCategorySearchModel searchModel)
        {
            ProductCategories = !string.IsNullOrWhiteSpace(searchModel.Name)
                ? _productCategoryApplication.Search(searchModel).OrderByDescending(x => x.Id).ToList()
                : _productCategoryApplication.Search().OrderByDescending(x => x.Id).ToList();
        }

        public IActionResult OnGetCreate()
        {
            return Partial("Create", new CreateProductCategory());
        }

        public JsonResult OnPostCreate(CreateProductCategory command)
        {
            var operationResult = _productCategoryApplication.Create(command);

            return new JsonResult(operationResult);
        }

        public IActionResult OnGetEdit(long id)
        {
            var productCategory = _productCategoryApplication.GetDetails(id);
            return Partial("Edit", productCategory);
        }

        public JsonResult OnPostEdit(EditProductCategory command)
        {
            if (!ModelState.IsValid)
                return new JsonResult(new OperationResult().Failed("لظفا مقادیر ورودی را بررسی نمایید"));
            var operationResult = _productCategoryApplication.Edit(command);
            return new JsonResult(operationResult);
        }

        public JsonResult OnGetRemove(long id)
        {
            var operationResult = _productCategoryApplication.Remove(id);
            return new JsonResult(operationResult);
        }

        public JsonResult OnGetRestore(long id)
        {
            var operationResult = _productCategoryApplication.Restore(id);
            return new JsonResult(operationResult);
        }
    }
}