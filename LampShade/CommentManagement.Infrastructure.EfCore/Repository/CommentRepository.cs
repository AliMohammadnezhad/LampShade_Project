using System.Collections.Generic;
using System.Linq;
using _0_Framework.Application;
using _0_FrameWork.Infrastructure;
using CommentManagement.Application.Contract.Comment;
using CommentManagement.Domain.CommentAgg;
using Microsoft.EntityFrameworkCore;
using ShopManagement.Infrastructure.EFCore;

namespace CommentManagement.Infrastructure.EfCore.Repository
{
    public class CommentRepository:RepositoryBase<long,Comment>,ICommentRepository
    {
        private readonly CommentContext _context;
        private readonly ShopContext _shopContext;
        public CommentRepository(CommentContext context, ShopContext shopContext) : base(context)
        {
            _context = context;
            _shopContext = shopContext;
        }

        public List<CommentViewModel> Search()
        {
            var products = _shopContext.Products.Select(x => new {x.Name, x.Id}).ToList();
            var comments = _context.Comments.Select(x => new CommentViewModel
            {
                
                ProductId = x.ProductId,
                Name = x.Name,
                CommentId = x.Id,
                CommentText = x.CommentText,
                CreateDate = x.CreationDate.ToFarsi(),
                Email = x.Email,
                IsConfirmed = x.IsConfirmed,
                

            }).OrderByDescending(x=>x.CommentId).ToList();

            comments.ForEach(comment=> comment.Product = products.FirstOrDefault(x=>x.Id == comment.ProductId)?.Name);

            return comments;
        }

        public List<CommentViewModel> Search(CommentSearchModel searchModel)
        {
            var products = _shopContext.Products.Select(x => new { x.Name, x.Id }).ToList();
            var comments = _context.Comments.Select(x => new CommentViewModel
            {
                ProductId = x.ProductId,
                Name = x.Name,
                CommentId = x.Id,
                CommentText = x.CommentText,
                CreateDate = x.CreationDate.ToFarsi(),
                Email = x.Email,
                IsConfirmed = x.IsConfirmed
            }).Where(x=> (searchModel.IsConfirmed)? x.IsConfirmed == false : x.IsConfirmed == null || x.ProductId == searchModel.ProductId||x.Email == searchModel.Email).ToList();

            comments.ForEach(comment => comment.Product = products.FirstOrDefault(x => x.Id == comment.ProductId)?.Name);

            return comments;
        }
    }
}
