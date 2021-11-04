using System.Collections.Generic;
using _0_FrameWork.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShopManagement.Application.Contracts.Product;
using ShopManagement.Application.Contracts.ProductPicture;
using ShopManagement.Configuration.Permissions;

namespace ServiceHost.Areas.Administration.Pages.Shop.ProductPictures
{
    public class IndexModel : PageModel
    {
        private readonly IProductPictureApplication _productPictureApplication;
        private readonly IProductApplication _productApplication;
        public SelectList Products;
        public List<ProductPictureViewModel> ProductsPictures;
        public ProductPictureSearchModel SearchModel;

        public IndexModel(IProductPictureApplication productPictureApplication, IProductApplication productApplication)
        {
            _productPictureApplication = productPictureApplication;
            _productApplication = productApplication;
            }

        [NeedsPermission(ShopPermissions.SearchProductPicture)]
        public void OnGet(ProductPictureSearchModel searchModel)
        {
            Products= new SelectList(_productApplication.GetProducts(), "Id", "Name");
            ProductsPictures = _productPictureApplication.Search(searchModel);
        }

        [NeedsPermission(ShopPermissions.CreateProductPicture)]
        public IActionResult OnGetCreate()
        {
            var commend = new CreateProductPicture
            {
                Products = _productApplication.GetProducts()
            };
            return Partial("Create", commend);
        }

        [NeedsPermission(ShopPermissions.CreateProductPicture)]
        public JsonResult OnPostCreate(CreateProductPicture command)
        {
            var operationResult = _productPictureApplication.Create(command);

            return new JsonResult(operationResult);
        }

        [NeedsPermission(ShopPermissions.EditProductPicture)]
        public IActionResult OnGetEdit(long id)
        {
            var product = _productPictureApplication.GetDetails(id);
            product.Products = _productApplication.GetProducts();
            return Partial("Edit", product);
        }

        [NeedsPermission(ShopPermissions.EditProductPicture)]
        public JsonResult OnPostEdit(EditProductPicture command)
        {
            var operationResult = _productPictureApplication.Edit(command);
            return new JsonResult(operationResult);
        }

        [NeedsPermission(ShopPermissions.RestoreProductPicture)]
        public JsonResult OnGetRestore(long id)
        {
            var isInStock = _productPictureApplication.Restore(id);
            return isInStock.IsSucceed ? new JsonResult(isInStock.Succeed()) : new JsonResult(isInStock);
        }

        [NeedsPermission(ShopPermissions.RestoreProductPicture)]

        public JsonResult OnGetRemove(long id)
        {
            var notInStock = _productPictureApplication.Remove(id);
            return notInStock.IsSucceed ? new JsonResult(notInStock.Succeed()) : new JsonResult(notInStock);
        }
    }
}