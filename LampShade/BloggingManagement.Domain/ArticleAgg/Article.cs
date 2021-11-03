using System;
using _0_FrameWork.Domain;
using BloggingManagement.Domain.ArticleCategoryAgg;

namespace BloggingManagement.Domain.ArticleAgg
{
    public class Article : EntityBase
    {
        public string Title { get; private set; }
        public string ShortDescription { get; private set; }
        public string Description { get; private set; }
        public string Picture { get; private set; }
        public string PictureAlt { get; private set; }
        public string PictureTitle { get; private set; }
        public DateTime PublishDate { get; private set; }
        public string Slug { get; private set; }
        public string KeyWords { get; private set; }
        public string MetaDescription { get; private set; }
        public string CanonicalAddress { get; private set; }
        public long CategoryId { get; private set; }
        public ArticleCategory ArticleCategory { get; private set; }


        public Article(string title, string shortDescription, string description,
            string picture, string pictureAlt, string pictureTitle,DateTime publishDate, string slug,
            string keyWords, string metaDescription, string canonicalAddress, long categoryId)
        {
            Title = title;
            ShortDescription = shortDescription;
            Description = description;
            Picture = picture;
            PictureAlt = pictureAlt;
            PictureTitle = pictureTitle;
            Slug = slug;
            KeyWords = keyWords;
            MetaDescription = metaDescription;
            CanonicalAddress = canonicalAddress;
            CategoryId = categoryId;
            CreationDate = DateTime.Now;
            PublishDate = publishDate;
        }


        public void Edit(string title, string shortDescription, string description,
            string picture, string pictureAlt, string pictureTitle, DateTime publishDate, string slug,
            string keyWords, string metaDescription, string canonicalAddress, long categoryId)
        {
            Title = title;
            ShortDescription = shortDescription;
            Description = description;
            if (!string.IsNullOrWhiteSpace(picture))
                Picture = picture;
            PictureAlt = pictureAlt;
            PictureTitle = pictureTitle;
            PublishDate = publishDate;
            Slug = slug;
            KeyWords = keyWords;
            MetaDescription = metaDescription;
            CanonicalAddress = canonicalAddress;
            CategoryId = categoryId;
        }
    }
}
