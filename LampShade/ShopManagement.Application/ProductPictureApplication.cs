using System.Collections.Generic;
using _0_Framework.Application;
using _0_FrameWork.Application;
using ShopManagement.Application.Contracts.ProductPicture;
using ShopManagement.Domain.ProductPictureAgg;

namespace ShopManagement.Application
{
    public class ProductPictureApplication : IProductPictureApplication
    {
        private readonly IProductPictureRepository _productPictureRepository;
        private readonly IFileUploader _fileUploader;
        public ProductPictureApplication(IProductPictureRepository productPictureRepository, IFileUploader fileUploader)
        {
            _productPictureRepository = productPictureRepository;
            _fileUploader = fileUploader;
        }
        public OperationResult Create(CreateProductPicture command)
        {
            var operationResult = new OperationResult();

            var slugs = _productPictureRepository.GetProductCategorySlugByProductId(command.ProductId);

            var path = $"{slugs.ProductCategorySlug}/{slugs.ProductSlug}";
            var picturePath = _fileUploader.UploadFile(command.Picture, path);
            var productPicture = new ProductPicture(command.ProductId, picturePath, command.PictureAlt,command.PictureTitle);
            _productPictureRepository.Create(productPicture);
            _productPictureRepository.SaveChange();
            return operationResult.Succeed();
        }

        public OperationResult Edit(EditProductPicture command)
        {
            var operationResult = new OperationResult();
            var productPicture = _productPictureRepository.GetProductsPictureWithCategory(command.Id);

            if (productPicture == null)
                return operationResult.Failed(ApplicationMessages.RecordNotFound);

            var path = $"{productPicture.Product.Category.Slug}/{productPicture.Product.Slug}";
            var picturePath = _fileUploader.UploadFile(command.Picture, path);

            productPicture.Edit(command.ProductId, picturePath, command.PictureAlt,command.PictureTitle);
            _productPictureRepository.SaveChange();
            return operationResult.Succeed();
        }

        public OperationResult Remove(long id)
        {
            var operationResult = new OperationResult();
            var productPicture = _productPictureRepository.Get(id);
            if (productPicture == null)
                return operationResult.Failed(ApplicationMessages.RecordNotFound);

            productPicture.Remove();
            _productPictureRepository.SaveChange();
            return operationResult.Succeed();
        }

        public OperationResult Restore(long id)
        {
            var operationResult = new OperationResult();
            var productPicture = _productPictureRepository.Get(id);
            if (productPicture == null)
                return operationResult.Failed(ApplicationMessages.RecordNotFound);

            productPicture.Restore();
            _productPictureRepository.SaveChange();
            return operationResult.Succeed();
        }



        public List<ProductPictureViewModel> Search(ProductPictureSearchModel searchModel)
        {
            return searchModel.ProductId == 0 ? _productPictureRepository.Search() : _productPictureRepository.Search(searchModel);
        }

        public EditProductPicture GetDetails(long id)
        {
            return _productPictureRepository.GetDetails(id);
        }
    }
}
