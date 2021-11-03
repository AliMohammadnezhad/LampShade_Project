using System;
using System.Collections.Generic;
using System.Linq;
using _0_Framework.Application;
using _01_LampShadeQueries.Contracts.Article;
using _01_LampShadeQueries.Contracts.Comment;
using BloggingManagement.Infrastructure.EFCore;
using CommentManagement.Infrastructure.EfCore;
using Microsoft.EntityFrameworkCore;

namespace _01_LampShadeQueries.Queries
{
    public class ArticleQuery : IArticleQuery
    {
        private readonly BloggingContext _bloggingContext;
        private readonly ICommentQuery _commentQuery;
        public ArticleQuery(BloggingContext bloggingContext, ICommentQuery commentQuery)
        {
            _bloggingContext = bloggingContext;
            _commentQuery = commentQuery;
        }

        public List<ArticleQueryModel> GetLatestArticles()
        {
            return _bloggingContext.Articles.Include(x => x.ArticleCategory).Where(x => x.PublishDate <= DateTime.Now).Select(x => new ArticleQueryModel
            {
                PublishDate = x.PublishDate.GetFarsiDay(),
                Picture = x.Picture,
                Title = x.Title,
                Slug = x.Slug,
                ShortDescription = x.ShortDescription,
                Category = x.ArticleCategory.Name,
                CategorySlug = x.ArticleCategory.Slug,
                PictureAlt = x.PictureAlt,
                Id = x.Id,
                MonthName = x.PublishDate.GetFarsiMothName(),
                StableDate = x.PublishDate.ToFarsi()
            }).OrderByDescending(x => x.Id).Take(6).ToList();
        }

        public List<ArticleQueryModel> GetArticles(string? slug)
        {
            var articles = _bloggingContext.Articles.Include(x => x.ArticleCategory)
                .Where(x=>x.PublishDate <= DateTime.Now)
                .Select(x => new ArticleQueryModel
                {
                    Picture = x.Picture,
                    PictureAlt = x.PictureAlt,
                    PictureTitle = x.PictureTitle,
                    Title = x.Title,
                    Category = x.ArticleCategory.Name,
                    ShortDescription = x.ShortDescription,
                    PublishDate = x.PublishDate.ToFarsi(),
                    Slug = x.Slug,
                    CategorySlug = x.ArticleCategory.Slug,
                    Id = x.Id
                    
                }).OrderByDescending(x=>x.Id);

            return !string.IsNullOrWhiteSpace(slug) ? articles.Where(x => x.CategorySlug == slug).ToList() : articles.ToList();
        }

        public ArticleQueryModel GetArticleBy(string slug)
        {
            var article = _bloggingContext.Articles.Include(x => x.ArticleCategory).Select(x => new ArticleQueryModel
            {
                Id = x.Id,
                Category = x.ArticleCategory.Name,
                Picture = x.Picture,
                PictureAlt = x.PictureAlt,
                PictureTitle = x.PictureTitle,
                Slug = x.Slug,
                PublishDate = x.PublishDate.ToFarsi(),
                Description = x.Description,
                CategoryId = x.CategoryId,
                CategorySlug = x.ArticleCategory.Slug,
                KeyWords = x.KeyWords,
                MetaDescription = x.MetaDescription,
                MonthName = x.PublishDate.GetFarsiMothName(),
                ShortDescription = x.ShortDescription,
                Title = x.Title
                
            }).FirstOrDefault(x => x.Slug == slug);

            if (article != null) article.Comments = _commentQuery.GetArticleComments(article.Id);
            return article;
        }
    }
}
