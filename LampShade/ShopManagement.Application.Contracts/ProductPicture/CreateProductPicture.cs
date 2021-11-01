using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using _0_Framework.Application;
using _0_FrameWork.Application;
using Microsoft.AspNetCore.Http;
using ShopManagement.Application.Contracts.Product;

namespace ShopManagement.Application.Contracts.ProductPicture
{
    public class CreateProductPicture
    {
        [Range(0,100000,ErrorMessage = ValidationMessages.IsRequired)]
        public long ProductId { get; set; }

        [MaxFileSize(3*1024*1024,ErrorMessage = ValidationMessages.MaxFileSize)]
        [FileExtensionLimitation(new[]{".jpg",".png",".jpeg"})]
        public IFormFile Picture { get; set; }
        [Required(ErrorMessage = ValidationMessages.IsRequired)]

        public string PictureAlt { get; set; }
        [Required(ErrorMessage = ValidationMessages.IsRequired)]

        public string PictureTitle { get; set; }

        public List<ProductViewModel> Products { get; set; }
    }
}
