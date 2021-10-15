using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShopManagement.Application.Contracts.Product;
using ShopManagement.Application.Contracts.ProductPicture;

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

        public void OnGet(ProductPictureSearchModel searchModel)
        {
            Products= new SelectList(_productApplication.GetProducts(), "Id", "Name");
            ProductsPictures = _productPictureApplication.Search(searchModel);
        }

        public IActionResult OnGetCreate()
        {
            var commend = new CreateProductPicture
            {
                Products = _productApplication.GetProducts()
            };
            return Partial("Create", commend);
        }

        public JsonResult OnPostCreate(CreateProductPicture command)
        {
            var operationResult = _productPictureApplication.Create(command);

            return new JsonResult(operationResult);
        }

        public IActionResult OnGetEdit(long id)
        {
            var product = _productPictureApplication.GetDetails(id);
            product.Products = _productApplication.GetProducts();
            return Partial("EditSlide", product);
        }

        public JsonResult OnPostEdit(EditProductPicture command)
        {
            var operationResult = _productPictureApplication.Edit(command);
            return new JsonResult(operationResult);
        }

        public JsonResult OnGetRestore(long id)
        {
            var isInStock = _productPictureApplication.Restore(id);
            return isInStock.IsSucceed ? new JsonResult(isInStock.Succeed()) : new JsonResult(isInStock);
        }

        public JsonResult OnGetRemove(long id)
        {
            var notInStock = _productPictureApplication.Remove(id);
            return notInStock.IsSucceed ? new JsonResult(notInStock.Succeed()) : new JsonResult(notInStock);
        }
    }
}