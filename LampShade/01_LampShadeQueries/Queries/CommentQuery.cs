using System.Collections.Generic;
using System.Linq;
using _01_LampShadeQueries.Contracts.Comment;
using CommentManagement.Infrastructure.EfCore;

namespace _01_LampShadeQueries.Queries
{
    public class CommentQuery : ICommentQuery
    {
        private readonly CommentContext _commentContext;

        public CommentQuery(CommentContext commentContext)
        {
            _commentContext = commentContext;
        }

        public List<CommentQueryModel> GetProductComment(long id)
        {
            return _commentContext.Comments.Where(x => x.IsConfirmed && x.ProductId == id).Select(x => new CommentQueryModel
            {
                ProductId = x.ProductId,
                MessageText = x.CommentText,
                Name = x.Name,
                CommentId = x.Id
            }).OrderByDescending(x => x.CommentId).ToList();
        }
    }
}
