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
        public ProductCategorySearchViewModel SearchModel;
        private readonly IProductCategoryApplication _productCategoryApplication;

        public IndexModel(IProductCategoryApplication productCategoryApplication)
        {
            _productCategoryApplication = productCategoryApplication;
        }

        public List<ProductCategorySearchViewModel> ProductCategories;
        public void OnGet(ProductCategorySearchModel searchModel)
        {
            ProductCategories = !string.IsNullOrWhiteSpace(searchModel.Name) ?
                _productCategoryApplication.Search(searchModel).OrderByDescending(x => x.Id).ToList() :
                _productCategoryApplication.Search().OrderByDescending(x=>x.Id).ToList();
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
            var operationResult = _productCategoryApplication.Edit(command);
            return new JsonResult(operationResult);
        }
    }
}
