using System;
using System.Collections.Generic;
using _0_Framework.Application;
using _0_FrameWork.Application;
using BloggingManagement.Application.Contract.Article;
using BloggingManagement.Domain.ArticleAgg;
using BloggingManagement.Domain.ArticleCategoryAgg;

namespace BloggingManagement.Application
{
    public class ArticleApplication : IArticleApplication
    {
        private readonly IArticleRepository _articleRepository;
        private readonly IFileUploader _fileUploader;
        private readonly IArticleCategoryRepository _articleCategoryRepository;
        public ArticleApplication(IArticleRepository articleRepository, IFileUploader fileUploader, IArticleCategoryRepository articleCategoryRepository)
        {
            _articleRepository = articleRepository;
            _fileUploader = fileUploader;
            _articleCategoryRepository = articleCategoryRepository;
        }

        public OperationResult Create(CreateArticle command)
        {
            var operationResult = new OperationResult();
            if (_articleRepository.Exists(x => x.Title == command.Title))
                return operationResult.Failed(ApplicationMessages.DuplicatedRecord);

            command.CategorySlug = _articleCategoryRepository.GetCategorySlugBy(command.CategoryId);
            var slug = command.Slug.Slugify();
            var path = $"ArticleCategoryPictures/{command.CategorySlug}/{slug}";
            var picturePath = _fileUploader.UploadFile(command.Picture, path);

            if (string.IsNullOrWhiteSpace(command.PublishDate))
                command.PublishDate = DateTime.Now.ToFarsi();

            var article = new Article(command.Title, command.ShortDescription, command.Description, picturePath,
                command.PictureAlt, command.PictureTitle
                , command.PublishDate.ToGeorgianDateTime(), command.Slug, command.KeyWords, command.MetaDescription,
                command.CanonicalAddress, command.CategoryId);

            _articleRepository.Create(article);
            _articleRepository.SaveChange();
            return operationResult.Succeed();
        }

        public OperationResult Edit(EditArticle command)
        {
            var operationResult = new OperationResult();
            var article = _articleRepository.Get(command.Id);
            if (article == null)
                return operationResult.Failed(ApplicationMessages.RecordNotFound);
            if (_articleRepository.Exists(x => x.Id != command.Id && x.Title == command.Title))
                return operationResult.Failed(ApplicationMessages.DuplicatedRecord);

            command.CategorySlug = _articleCategoryRepository.GetCategorySlugBy(command.CategoryId);
            var slug = command.Slug.Slugify();
            var path = $"ArticleCategoryPictures/{command.CategorySlug}/{slug}";
            var picturePath = _fileUploader.UploadFile(command.Picture, path);

            article.Edit(command.Title, command.ShortDescription, command.Description, picturePath,
                command.PictureAlt, command.PictureTitle
                , command.PublishDate.ToGeorgianDateTime(), command.Slug, command.KeyWords, command.MetaDescription,
                command.CanonicalAddress, command.CategoryId);
            _articleRepository.SaveChange();
            return operationResult.Succeed();
        }

        public List<ArticleViewModel> Search(ArticleSearchModel command)
        {
            if (!string.IsNullOrWhiteSpace(command.Title) || command.CategoryId > 0)
                _articleRepository.Search(command);
            return _articleRepository.Search();
        }

        public EditArticle GetDetails(long id)
        {
            return _articleRepository.GetDetails(id);
        }

        public List<ArticleViewModel> GetArticles()
        {
            return _articleRepository.GetArticles();
        }
    }
}
