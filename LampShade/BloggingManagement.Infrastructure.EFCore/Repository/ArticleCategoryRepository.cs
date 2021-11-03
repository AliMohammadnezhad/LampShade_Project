using System.Collections.Generic;
using System.Linq;
using _0_Framework.Application;
using _0_FrameWork.Infrastructure;
using BloggingManagement.Application.Contract.ArticleCategory;
using BloggingManagement.Domain.ArticleCategoryAgg;
using Microsoft.EntityFrameworkCore;

namespace BloggingManagement.Infrastructure.EFCore.Repository
{
    public class ArticleCategoryRepository : RepositoryBase<long, ArticleCategory>, IArticleCategoryRepository
    {
        private readonly BloggingContext _bloggingContext;
        public ArticleCategoryRepository(BloggingContext context) : base(context)
        {
            _bloggingContext = context;
        }

        public EditArticleCategory GetDetails(long id)
        {
            return _bloggingContext.ArticleCategories.Select(x => new EditArticleCategory
            {
                CanonicalAddress = x.CanonicalAddress,
                Description = x.Description,
                Id = x.Id,
                KeyWords = x.KeyWords,
                MetaDescription = x.MetaDescription,
                Name = x.Name,
                Slug = x.Slug,
                ShowOrder = x.ShowOrder,
                PictureTitle = x.PictureTitle,
                PictureAlt = x.PictureAlt

            }).FirstOrDefault(x => x.Id == id);
        }

        public List<ArticleCategoryViewModel> Search()
        {
            return _bloggingContext.ArticleCategories.Include(x=>x.Articles).Select(x => new ArticleCategoryViewModel
            {
                Name = x.Name,
                Picture = x.Picture,
                ShowOrder = x.ShowOrder,
                Description = x.Description,
                Id = x.Id,
                CreationDate = x.CreationDate.ToFarsi(),
                ArticleCount = x.Articles.Count
            }).OrderByDescending(x => x.Id).ToList();
        }

        public List<ArticleCategoryViewModel> Search(ArticleCategorySearchModel searchModel)
        {
            return _bloggingContext.ArticleCategories.Select(x => new ArticleCategoryViewModel
            {
                Description = x.Description,
                Id = x.Id,
                ShowOrder = x.ShowOrder,
                Name = x.Name,
                Picture = x.Picture,
                CreationDate = x.CreationDate.ToFarsi(),
                ArticleCount = x.Articles.Count
            }).Where(x => x.Name.Contains(searchModel.Name)).ToList();
        }

        public List<ArticleCategoryViewModel> GetArticleCategories()
        {
            return _bloggingContext.ArticleCategories.Select(x => new ArticleCategoryViewModel
            {
                Id = x.Id,
                Name = x.Name
            }).OrderByDescending(x => x.Id).ToList();
        }

        public string GetCategorySlugBy(long id)
        {
            return _bloggingContext.ArticleCategories.FirstOrDefault(x => x.Id == id)?.Slug;
        }
    }
}
