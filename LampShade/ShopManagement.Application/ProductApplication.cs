using System.Collections.Generic;
using _0_Framework.Application;
using _0_FrameWork.Application;
using ShopManagement.Application.Contracts.Product;
using ShopManagement.Domain.ProductAgg;

namespace ShopManagement.Application
{
    public class ProductApplication : IProductApplication
    {
        private readonly IProductRepository _productRepository;

        public ProductApplication(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public OperationResult Create(CreateProduct command)
        {
            var operation = new OperationResult();
            if (_productRepository.Exists(x => x.Name == command.Name))
                return operation.Failed(ApplicationMessages.DuplicatedRecord);
            command.Slug = command.Slug.Slugify();
            var product = new Product(command.Name, command.Code, command.UnitPrice, command.ShortDescription,
                command.Description, command.Picture, command.PictureAlt, command.PictureTitle, command.CategoryId,
                command.Slug, command.KeyWords, command.MetaDescription);
            _productRepository.Create(product);
            _productRepository.SaveChange();
            return operation.Succeed();
        }

        public OperationResult Edit(EditProduct command)
        {
            var operation = new OperationResult();
            var product = _productRepository.Get(command.Id);
            if (product == null) return operation.Failed(ApplicationMessages.RecordNotFound);
            if (_productRepository.Exists(x => x.Name == command.Name && x.Id != command.Id))
                return operation.Failed(ApplicationMessages.DuplicatedRecord);
            command.Slug = command.Slug.Slugify();
            product.EditProduct(command.Name, command.Code, command.UnitPrice, command.ShortDescription,
                command.Description, command.Picture, command.PictureAlt, command.PictureTitle, command.CategoryId,
                command.Slug, command.KeyWords, command.MetaDescription);
            _productRepository.SaveChange();
            return operation.Succeed();
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

        public OperationResult IsInStock(long id)
        {
            var operation = new OperationResult();
            var product = _productRepository.Get(id);
            if (product == null) return operation.Failed(ApplicationMessages.RecordNotFound);
            product.InStock();
            _productRepository.SaveChange();
            return operation.Succeed();
        }

        public OperationResult NotInStock(long id)
        {
            var operation = new OperationResult();
            var product = _productRepository.Get(id);
            if (product == null) return operation.Failed(ApplicationMessages.RecordNotFound);
            product.NotInStock();
            _productRepository.SaveChange();
            return operation.Succeed();
        }
    }
}