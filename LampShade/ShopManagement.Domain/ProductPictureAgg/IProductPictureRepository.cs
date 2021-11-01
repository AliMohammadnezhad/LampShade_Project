using System.Collections.Generic;
using _0_FrameWork.Domain;
using ShopManagement.Application.Contracts.ProductPicture;

namespace ShopManagement.Domain.ProductPictureAgg
{
    public interface IProductPictureRepository : IRepository<long, ProductPicture>
    {
        EditProductPicture GetDetails(long id);
        ProductPicture GetProductsPictureWithCategory(long id);
        ProductPictureUploaderViewModel GetProductCategorySlugByProductId(long id);
        List<ProductPictureViewModel> Search();
        List<ProductPictureViewModel> Search(ProductPictureSearchModel searchModel);

    }
}
