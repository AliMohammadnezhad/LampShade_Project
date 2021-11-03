using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using _0_Framework.Application;
using _0_FrameWork.Application;
using BloggingManagement.Application.Contract.ArticleCategory;
using Microsoft.AspNetCore.Http;

namespace BloggingManagement.Application.Contract.Article
{
    public class CreateArticle
    {

        [MaxLength(500, ErrorMessage = ValidationMessages.MaxLength)]
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string Title { get; set; }
        [MaxLength(1000, ErrorMessage = ValidationMessages.MaxLength)]
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string ShortDescription { get; set; }
        public string Description { get; set; }
        [FileExtensionLimitation(new []{".jpg",".jpeg",".png"})]
        [MaxFileSize(3*1024*1024,ErrorMessage = ValidationMessages.MaxFileSize)]

        public IFormFile Picture { get; set; }
        [MaxLength(500, ErrorMessage = ValidationMessages.MaxLength)]
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string PictureAlt { get; set; }
        [MaxLength(500, ErrorMessage = ValidationMessages.MaxLength)]
        public string PictureTitle { get; set; }
        public string PublishDate { get; set; }
        [MaxLength(600, ErrorMessage = ValidationMessages.MaxLength)]
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string Slug { get; set; }
        [MaxLength(100, ErrorMessage = ValidationMessages.MaxLength)]
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string KeyWords { get; set; }
        [MaxLength(150, ErrorMessage = ValidationMessages.MaxLength)]
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string MetaDescription { get; set; }
        [MaxLength(1000, ErrorMessage = ValidationMessages.MaxLength)]
        public string CanonicalAddress { get; set; }
        public string CategorySlug { get; set; }
        public long CategoryId { get; set; }

    }
}
