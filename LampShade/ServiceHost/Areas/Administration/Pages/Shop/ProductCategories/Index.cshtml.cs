using System.Collections.Generic;
using System.Linq;
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
            return Partial("EditSlide", productCategory);
        }

        public JsonResult OnPostEdit(EditProductCategory command)
        {
            var operationResult = _productCategoryApplication.Edit(command);
            return new JsonResult(operationResult);
        }
    }
}