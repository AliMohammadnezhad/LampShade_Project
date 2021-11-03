using _01_LampShadeQueries.Contracts.Comment;
using _01_LampShadeQueries.Contracts.Product;
using CommentManagement.Application.Contract.Comment;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ServiceHost.Pages
{
    public class ProductModel : PageModel
    {
        public ProductQueryModel Product;
        public CommentQueryModel Comment;
        private readonly IProductQuery _productQuery;
        private readonly ICommentApplication _commentApplication;

        public ProductModel(IProductQuery productQuery, ICommentApplication commentApplication)
        {
            _productQuery = productQuery;
            _commentApplication = commentApplication;
        }

        public void OnGet(string id)
        {
            Product = _productQuery.GetProductDetails(id);

        }

        public IActionResult OnPost(AddComment command,string productSlug)
        {
            command.Type = CommentsType.Product ;
            _commentApplication.Add(command);
            return RedirectToPage("./Product", new { Id = productSlug });
        }
    }
}
