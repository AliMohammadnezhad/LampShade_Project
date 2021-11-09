using System.Collections.Generic;
using System.Linq;
using _0_Framework.Application;
using _0_FrameWork.Infrastructure;
using BloggingManagement.Infrastructure.EFCore;
using CommentManagement.Application.Contract.Comment;
using CommentManagement.Domain.CommentAgg;
using ShopManagement.Infrastructure.EFCore;

namespace CommentManagement.Infrastructure.EfCore.Repository
{
    public class CommentRepository:RepositoryBase<long,Comment>,ICommentRepository
    {
        private readonly CommentContext _context;
        private readonly ShopContext _shopContext;
        private readonly BloggingContext _bloggingContext;
        public CommentRepository(CommentContext context, ShopContext shopContext, BloggingContext bloggingContext) : base(context)
        {
            _context = context;
            _shopContext = shopContext;
            _bloggingContext = bloggingContext;
        }

        public List<CommentViewModel> SearchProducts()
        {
            var products = _shopContext.Products.Select(x => new { x.Name, x.Id }).ToList();
            var comments = _context.Comments.Where(x => x.Type == CommentsType.Product).Select(x => new CommentViewModel
            {
                Name = x.Name,
                CommentId = x.Id,
                CommentText = x.CommentText,
                CreateDate = x.CreationDate.ToFarsi(),
                Email = x.Email,
                IsConfirmed = x.IsConfirmed,
                OwnerRecordId = x.OwnerRecordId,

            }).OrderByDescending(x=>x.CommentId).ToList();

            comments.ForEach(comment=>comment.OwnerRecordName = products.FirstOrDefault(x=>x.Id == comment.OwnerRecordId)?.Name);
            return comments;
        }

        public List<CommentViewModel> SearchProducts(CommentSearchModel searchModel)
        {
            var products = _shopContext.Products.Select(x => new { x.Name, x.Id }).ToList();
            var comments = _context.Comments.Where(x => x.Type == CommentsType.Product).Select(x => new CommentViewModel
            {
                OwnerRecordId = x.OwnerRecordId,

                Name = x.Name,
                CommentId = x.Id,
                CommentText = x.CommentText,
                CreateDate = x.CreationDate.ToFarsi(),
                Email = x.Email,
                IsConfirmed = x.IsConfirmed
            }).Where(x=> (searchModel.IsConfirmed)? x.IsConfirmed == false : x.IsConfirmed == null || x.OwnerRecordId == searchModel.OwnerRecordId||x.Email == searchModel.Email).ToList();
            comments.ForEach(comment => comment.OwnerRecordName = products.FirstOrDefault(x => x.Id == comment.OwnerRecordId)?.Name);

            return comments;
        }

        public List<CommentViewModel> SearchArticles()
        {
            var articles = _bloggingContext.Articles.Select(x => new { x.Title, x.Id }).ToList();
            var comments = _context.Comments.Where(x=>x.Type == CommentsType.Article).Select(x => new CommentViewModel
            {
                Name = x.Name,
                CommentId = x.Id,
                CommentText = x.CommentText,
                CreateDate = x.CreationDate.ToFarsi(),
                Email = x.Email,
                IsConfirmed = x.IsConfirmed,
                OwnerRecordId = x.OwnerRecordId,
                
            }).OrderByDescending(x => x.CommentId).ToList();

            comments.ForEach(comment => comment.OwnerRecordName = articles.FirstOrDefault(x => x.Id == comment.OwnerRecordId)?.Title);
            return comments;
        }

        public List<CommentViewModel> SearchArticles(CommentSearchModel searchModel)
        {
            var articles = _bloggingContext.Articles.Select(x => new { x.Title, x.Id }).ToList();
            var comments = _context.Comments.Where(x => x.Type == CommentsType.Article).Select(x => new CommentViewModel
            {
                Name = x.Name,
                CommentId = x.Id,
                CommentText = x.CommentText,
                CreateDate = x.CreationDate.ToFarsi(),
                Email = x.Email,
                IsConfirmed = x.IsConfirmed,
                OwnerRecordId = x.OwnerRecordId,

            }).Where(x => (searchModel.IsConfirmed) ? x.IsConfirmed == false : x.IsConfirmed == null || x.OwnerRecordId == searchModel.OwnerRecordId || x.Email == searchModel.Email).OrderByDescending(x => x.CommentId).ToList();

            comments.ForEach(comment => comment.OwnerRecordName = articles.FirstOrDefault(x => x.Id == comment.OwnerRecordId)?.Title);
            return comments;
        }

        public List<CommentViewModel> GetLatestComment()
        {
            var products = _shopContext.Products.Select(x => new { x.Name, x.Id }).ToList();
            var articles = _bloggingContext.Articles.Select(x => new { x.Title, x.Id }).ToList();
            var comments = _context.Comments.Select(x => new CommentViewModel
            {
                Name = x.Name,
                CommentId = x.Id,
                CreateDate = x.CreationDate.ToFarsi(),
                IsConfirmed = x.IsConfirmed,
                OwnerRecordId = x.OwnerRecordId,
                CommentType = x.Type
            }).OrderByDescending(x => x.CommentId).Take(10).ToList();

            foreach (var comment in comments)
            {
                if (comment.CommentType == CommentsType.Product)
                {
                    comment.OwnerRecordName = products.FirstOrDefault(x => x.Id == comment.OwnerRecordId)?.Name;
                }
                else
                {
                    comment.OwnerRecordName = articles.FirstOrDefault(x => x.Id == comment.OwnerRecordId)?.Title;
                }
            }

            return comments;
        }

        public double TotalComment()
        {
            return _context.Comments.Count();
        }
    }
}
