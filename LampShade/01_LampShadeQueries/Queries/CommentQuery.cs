using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using _0_Framework.Application;
using _01_LampShadeQueries.Contracts.Comment;
using CommentManagement.Application.Contract.Comment;
using CommentManagement.Infrastructure.EfCore;
using Microsoft.EntityFrameworkCore;

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
            return _commentContext.Comments
                .Where(x => x.Type == CommentsType.Product)
                .Where(x => x.IsConfirmed && x.OwnerRecordId == id)
                .Select(x => new CommentQueryModel
                {

                    MessageText = x.CommentText,
                    Name = x.Name,
                    CommentId = x.Id
                }).OrderByDescending(x => x.CommentId).ToList();
        }

        public List<CommentQueryModel> GetArticleComments(long id)
        {
            var comments =  _commentContext.Comments
                .Where(x => x.Type == CommentsType.Article)
                .Where(x => x.IsConfirmed && x.OwnerRecordId == id)
                .Where(x => x.ParentId == 0)
                .Include(x=>x.Children)
                .Select(x => new CommentQueryModel
                {
                    MessageText = x.CommentText,
                    Name = x.Name,
                    CommentId = x.Id,
                    OwnerRecordId = x.OwnerRecordId,
                    ParentId = x.ParentId,
                    CreationDate = x.CreationDate.ToFarsi(),
                    Children = x.Children.Where(x=>x.IsConfirmed == true).Select(y=>new CommentQueryModel
                    {
                        Name = y.Name,
                        CommentId = x.Id,
                        CreationDate = y.CreationDate.ToFarsi(),
                        OwnerRecordId = y.OwnerRecordId,
                        MessageText = y.CommentText,
                        ParentId = y.ParentId,
                        
                    }).ToList()
                }).OrderByDescending(x => x.CommentId).ToList();

            return comments;

        }
    }
}
