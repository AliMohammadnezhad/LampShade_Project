using System.Collections.Generic;
using CommentManagement.Application.Contract.Comment;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShopManagement.Application.Contracts.Product;

namespace ServiceHost.Areas.Administration.Pages.Comments
{
    public class IndexModel : PageModel
    {
        public List<CommentViewModel> Comments;
        public CommentSearchModel SearchModel;
        public SelectList Products;
        private readonly ICommentApplication _commentApplication;
        private readonly IProductApplication _productApplication;

        public IndexModel(ICommentApplication commentApplication, IProductApplication productApplication)
        {
            _commentApplication = commentApplication;
            _productApplication = productApplication;
        }

        public void OnGet(CommentSearchModel searchModel)
        {
            Products = new SelectList(_productApplication.GetProducts(), "Id", "Name");
            Comments = _commentApplication.Search(searchModel);
        }

        public JsonResult OnGetConfirm(long id)
        {
            var operationResult = _commentApplication.Confirm(id);
            return operationResult.IsSucceed ? new JsonResult(operationResult.Succeed()) : new JsonResult(operationResult);
        }

        public JsonResult OnGetUnConfirm(long id)
        {
            var operationResult = _commentApplication.UnConfirm(id);
            return operationResult.IsSucceed ? new JsonResult(operationResult.Succeed()) : new JsonResult(operationResult);
        }
    }
}
