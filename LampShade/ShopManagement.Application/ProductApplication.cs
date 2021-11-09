using System.Collections.Generic;
using _0_Framework.Application;
using _0_FrameWork.Application;
using Microsoft.AspNetCore.Http;
using ShopManagement.Application.Contracts.Product;
using ShopManagement.Domain.ProductAgg;
using ShopManagement.Domain.ProductCategoryAgg;

namespace ShopManagement.Application
{
    public class ProductApplication : IProductApplication
    {
        private readonly IProductRepository _productRepository;
        private readonly IProductCategoryRepository _categoryRepository;
        private readonly IFileUploader _fileUploader;
        public ProductApplication(IProductRepository productRepository, IProductCategoryRepository categoryRepository, IFileUploader fileUploader)
        {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
            _fileUploader = fileUploader;
        }

        public OperationResult Create(CreateProduct command)
        {
            var operation = new OperationResult();
            if (_productRepository.Exists(x => x.Name == command.Name))
                return operation.Failed(ApplicationMessages.DuplicatedRecord);

            command.Slug = command.Slug.Slugify();
            var categorySlug = _categoryRepository.GetSlugBy(command.CategoryId);
            var picturePath = GetPicturePath(command.Picture,command.Slug,categorySlug);
            var product = new Product(command.Name, command.Code,  command.ShortDescription,
                command.Description, picturePath, command.PictureAlt, command.PictureTitle, command.CategoryId,
                command.Slug, command.KeyWords, command.MetaDescription);
            _productRepository.Create(product);
            _productRepository.SaveChange();
            return operation.Succeed();
        }

        public OperationResult Edit(EditProduct command)
        {
            var operation = new OperationResult();
            var product = _productRepository.GetProductWithCategoryBy(command.Id);
            if (product == null) return operation.Failed(ApplicationMessages.RecordNotFound);
            if (_productRepository.Exists(x => x.Name == command.Name && x.Id != command.Id))
                return operation.Failed(ApplicationMessages.DuplicatedRecord);

            command.Slug = command.Slug.Slugify();
            var pictureName = GetPicturePath(command.Picture, product.Category.Slug, command.Slug);

            product.EditProduct(command.Name, command.Code,  command.ShortDescription,
                command.Description, pictureName, command.PictureAlt, command.PictureTitle, command.CategoryId,
                command.Slug, command.KeyWords, command.MetaDescription);
            _productRepository.SaveChange();
            return operation.Succeed();
        }

        private string GetPicturePath(IFormFile commandPicture, string categorySlug, string productSlug)
        {
            var path = $"{categorySlug}/{productSlug}";
            var picturePath = _fileUploader.UploadFile(commandPicture, path);
            return picturePath;
        }

        public EditProduct GetDetails(long id)
        {
            return _productRepository.GetDetails(id);
        }

        public List<ProductViewModel> Search(ProductSearchModel searchModel)
        {
            if (searchModel.CategoryId != 0 && !string.IsNullOrWhiteSpace(searchModel.Code) && !string.IsNullOrWhiteSpace(searchModel.Name)) return _productRepository.Search(searchModel);
            return _productRepository.Search();
        }

        public List<ProductViewModel> GetProducts()
        {
            return _productRepository.GetProducts();
        }

        public double GetAllProductsCount()
        {
            return _productRepository.GetAllProductCount();
        }
    }
}