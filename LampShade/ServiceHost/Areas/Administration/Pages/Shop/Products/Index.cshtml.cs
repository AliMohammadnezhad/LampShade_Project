using System.Collections.Generic;
using _0_FrameWork.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShopManagement.Application.Contracts.Product;
using ShopManagement.Application.Contracts.ProductCategory;
using ShopManagement.Configuration.Permissions;

namespace ServiceHost.Areas.Administration.Pages.Shop.Products
{
    public class IndexModel : PageModel
    {
        private readonly IProductApplication _productApplication;
        private readonly IProductCategoryApplication _productCategoryApplication;
        public SelectList ProductCategories;
        public List<ProductViewModel> Products;
        public ProductSearchModel SearchModel;

        public IndexModel(IProductApplication productApplication,
            IProductCategoryApplication productCategoryApplication)
        {
            _productApplication = productApplication;
            _productCategoryApplication = productCategoryApplication;
        }

        [NeedsPermission(ShopPermissions.ListProducts)]
        public void OnGet(ProductSearchModel searchModel)
        {
            ProductCategories = new SelectList(_productCategoryApplication.GetProductCategories(), "Id", "Name");
            Products = _productApplication.Search(searchModel);
        }

        [NeedsPermission(ShopPermissions.CreateProduct)]
        public IActionResult OnGetCreate()
        {
            var commend = new CreateProduct
            {
                ProductCategories = _productCategoryApplication.GetProductCategories()
            };
            return Partial("Create", commend);
        }

        [NeedsPermission(ShopPermissions.CreateProduct)]
        public JsonResult OnPostCreate(CreateProduct command)
        {
            var operationResult = _productApplication.Create(command);

            return new JsonResult(operationResult);
        }

        [NeedsPermission(ShopPermissions.EditProduct)]
        public IActionResult OnGetEdit(long id)
        {
            var product = _productApplication.GetDetails(id);
            product.ProductCategories = _productCategoryApplication.GetProductCategories();
            return Partial("Edit", product);
        }


        [NeedsPermission(ShopPermissions.EditProduct)]
        public JsonResult OnPostEdit(EditProduct command)
        {
            var operationResult = _productApplication.Edit(command);
            return new JsonResult(operationResult);
        }


    }
}