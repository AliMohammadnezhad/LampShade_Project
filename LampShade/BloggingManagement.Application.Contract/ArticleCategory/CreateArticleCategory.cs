using System.ComponentModel.DataAnnotations;
using _0_Framework.Application;
using _0_FrameWork.Application;
using Microsoft.AspNetCore.Http;

namespace BloggingManagement.Application.Contract.ArticleCategory
{
    public class CreateArticleCategory
    {
        [MaxLength(150, ErrorMessage = ValidationMessages.MaxLength)]
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string Name { get; set; }
        [FileExtensionLimitation(new[] { ".jpg", ".jpeg", ".png" })]
        [MaxFileSize(3 * 1024 * 1024, ErrorMessage = ValidationMessages.MaxFileSize)]
        public IFormFile Picture { get; set; }
        [MaxLength(1200, ErrorMessage = ValidationMessages.MaxLength)]
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string Description { get; set; }
        public int ShowOrder { get; set; }
        [MaxLength(250, ErrorMessage = ValidationMessages.MaxLength)]
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string Slug { get; set; }
        [MaxLength(100, ErrorMessage = ValidationMessages.MaxLength)]
        public string KeyWords { get; set; }
        [MaxLength(150, ErrorMessage = ValidationMessages.MaxLength)]

        public string MetaDescription { get; set; }
        [MaxLength(1000, ErrorMessage = ValidationMessages.MaxLength)]

        public string CanonicalAddress { get; set; }
        public string PictureAlt { get; set; }
        public string PictureTitle { get; set; }

    }

}
