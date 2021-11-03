using System;
using System.Collections.Generic;
using System.Linq;
using _0_Framework.Application;
using _0_FrameWork.Infrastructure;
using BloggingManagement.Application.Contract.Article;
using BloggingManagement.Domain.ArticleAgg;

namespace BloggingManagement.Infrastructure.EFCore.Repository
{
    public class ArticleRepository:RepositoryBase<long,Article>,IArticleRepository
    {
        private readonly BloggingContext _bloggingContext;
        public ArticleRepository(BloggingContext context) : base(context)
        {
            _bloggingContext = context;
        }

        public List<ArticleViewModel> Search()
        {
            var articleCategory = _bloggingContext.ArticleCategories.Select(x => new {x.Id, x.Name}).ToList();
            var articles = _bloggingContext.Articles.Select(x=>new ArticleViewModel
            {
                CreationDate = x.CreationDate.ToFarsi(),
                Id = x.Id,
                Picture = x.Picture,
                PublishDate = x.PublishDate.ToFarsi(),
                ShortDescription = x.ShortDescription.Substring(0,Math.Min(x.ShortDescription.Length,100)) + "...",
                Title = x.Title,
                CategoryId = x.CategoryId
            }).OrderByDescending(x=>x.Id).ToList();

            articles.ForEach(article => article.Category = articleCategory.FirstOrDefault(x=>x.Id == article.CategoryId)?.Name);
            return articles;
        }

        public List<ArticleViewModel> Search(ArticleSearchModel command)
        {
            var articleCategories = _bloggingContext.ArticleCategories.Select(x => new {x.Id, x.Name}).ToList();
            var articles = _bloggingContext.Articles.Select(x => new ArticleViewModel
            {

                CategoryId = x.CategoryId,
                CreationDate = x.CreationDate.ToFarsi(),
                Id = x.Id,
                Picture = x.Picture,
                PublishDate = x.PublishDate.ToFarsi(),
                ShortDescription = x.ShortDescription.Substring(0, Math.Min(x.ShortDescription.Length, 100)) + "...",
                Title = x.Title
            }).OrderByDescending(x => x.Id).ToList();

            articles.ForEach(article => article.Category = articleCategories.FirstOrDefault(x=>x.Id == article.CategoryId)?.Name);
            return articles;
        }

        public EditArticle GetDetails(long id)
        {
            return _bloggingContext.Articles.Select(x => new EditArticle
            {
                Id = x.Id,
                CanonicalAddress = x.CanonicalAddress,
                CategoryId = x.CategoryId,
                Description = x.Description,
                KeyWords = x.KeyWords,
                MetaDescription = x.MetaDescription,
                PictureTitle = x.PictureTitle,
                PictureAlt = x.PictureAlt,
                Title = x.Title,
                Slug = x.Slug,
                ShortDescription = x.ShortDescription,
                PublishDate = x.PublishDate.ToFarsi(),
            }).FirstOrDefault(x => x.Id == id);
        }

        public List<ArticleViewModel> GetArticles()
        {
            return _bloggingContext.Articles.Select(x => new ArticleViewModel
            {
                Title = x.Title,
                Id = x.Id
            }).OrderByDescending(x => x.Id).ToList();
        }
    }
}
