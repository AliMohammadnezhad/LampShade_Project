using System.Collections.Generic;
using _0_Framework.Application;
using _0_FrameWork.Application;
using BloggingManagement.Application.Contract.ArticleCategory;
using BloggingManagement.Domain.ArticleCategoryAgg;

namespace BloggingManagement.Application
{
    public class ArticleCategoryApplication : IArticleCategoryApplication
    {
        private readonly IArticleCategoryRepository _articleCategoryRepository;
        private readonly IFileUploader _fileUploader;
        public ArticleCategoryApplication(IArticleCategoryRepository articleCategoryRepository, IFileUploader fileUploader)
        {
            _articleCategoryRepository = articleCategoryRepository;
            _fileUploader = fileUploader;
        }

        public OperationResult Create(CreateArticleCategory command)
        {
            var operationResult = new OperationResult();
            if (_articleCategoryRepository.Exists(x => x.Name == command.Name))
                return operationResult.Failed(ApplicationMessages.DuplicatedRecord);

            var slug = command.Slug.Slugify();
            var path = $"ArticleCategoryPictures/{slug}";
            var picturePath = _fileUploader.UploadFile(command.Picture, path);

            var articleCategory = new ArticleCategory(command.Name, picturePath,command.PictureAlt,command.PictureTitle, command.Description, command.ShowOrder,
                command.Slug, command.KeyWords, command.MetaDescription, command.CanonicalAddress);

            _articleCategoryRepository.Create(articleCategory);
            _articleCategoryRepository.SaveChange();
            return operationResult.Succeed();
        }

        public OperationResult Edit(EditArticleCategory command)
        {
            var operationResult = new OperationResult();
            var articleCategory = _articleCategoryRepository.Get(command.Id);
            if (articleCategory == null)
                return operationResult.Failed(ApplicationMessages.RecordNotFound);
            if (_articleCategoryRepository.Exists(x => x.Id == command.Id && x.Name == command.Name))
                return operationResult.Failed(ApplicationMessages.DuplicatedRecord);

            var slug = command.Slug.Slugify();
            var path = $"ArticleCategoryPictures/{slug}";
            var picturePath = _fileUploader.UploadFile(command.Picture, path);

            articleCategory.Edit(command.Name,picturePath, command.PictureAlt, command.PictureTitle, command.Description,command.ShowOrder,slug,command.KeyWords,command.MetaDescription,command.CanonicalAddress);
            _articleCategoryRepository.SaveChange();
            return operationResult.Succeed();
        }

        public EditArticleCategory GetDetails(long id)
        {
            return _articleCategoryRepository.GetDetails(id);
        }

        public List<ArticleCategoryViewModel> Search(ArticleCategorySearchModel searchModel)
        {
            return !string.IsNullOrWhiteSpace(searchModel.Name) ? _articleCategoryRepository.Search(searchModel) : _articleCategoryRepository.Search();
        }

        public List<ArticleCategoryViewModel> GetArticleCategories()
        {
            return _articleCategoryRepository.GetArticleCategories();
        }
    }
}
