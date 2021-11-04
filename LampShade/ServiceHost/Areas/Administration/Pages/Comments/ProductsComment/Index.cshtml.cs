using System.Collections.Generic;
using _0_FrameWork.Infrastructure;
using CommentManagement.Application.Contract.Comment;
using CommentManagement.Configuration.Permission;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShopManagement.Application.Contracts.Product;

namespace ServiceHost.Areas.Administration.Pages.Comments.ProductsComment
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
        [NeedsPermission(CommentPermissions.SearchComment)]
        public void OnGet(CommentSearchModel searchModel)
        {
            Products = new SelectList(_productApplication.GetProducts(), "Id", "Name");
            searchModel.CommentsType = CommentsType.Product;
            Comments = _commentApplication.Search(searchModel);
        }
        [NeedsPermission(CommentPermissions.ConfirmComment)]
        public JsonResult OnGetConfirm(long id)
        {
            var operationResult = _commentApplication.Confirm(id);
            return operationResult.IsSucceed ? new JsonResult(operationResult.Succeed()) : new JsonResult(operationResult);
        }
        [NeedsPermission(CommentPermissions.UnConfirmComment)]
        public JsonResult OnGetUnConfirm(long id)
        {
            var operationResult = _commentApplication.UnConfirm(id);
            return operationResult.IsSucceed ? new JsonResult(operationResult.Succeed()) : new JsonResult(operationResult);
        }
    }
}
