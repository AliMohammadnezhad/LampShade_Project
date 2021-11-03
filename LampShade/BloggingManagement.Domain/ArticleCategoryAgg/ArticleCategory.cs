using System;
using System.Collections.Generic;
using _0_FrameWork.Domain;
using BloggingManagement.Domain.ArticleAgg;

namespace BloggingManagement.Domain.ArticleCategoryAgg
{
    public class ArticleCategory : EntityBase
    {
        public string Name { get; private set; }
        public string Picture { get; private set; }
        public string PictureAlt { get; private set; }
        public string PictureTitle { get; private set; }
        public string Description { get; private set; }
        public int ShowOrder { get; private set; }
        public string Slug { get; private set; }
        public string KeyWords { get; private set; }
        public string MetaDescription { get; private set; }
        public string CanonicalAddress { get; private set; }
        public List<Article> Articles { get; private set; }
        public ArticleCategory(string name, string picture,string pictureAlt,string pictureTitle, string description,
            int showOrder, string slug, string keyWords, string metaDescription, string canonicalAddress)
        {
            Name = name;
            Picture = picture;
            Description = description;
            ShowOrder = showOrder;
            Slug = slug;
            KeyWords = keyWords;
            MetaDescription = metaDescription;
            CanonicalAddress = canonicalAddress;
            PictureTitle = pictureTitle;
            PictureAlt = pictureAlt;
            CreationDate = DateTime.Now;
        }

        public void Edit(string name, string picture, string pictureAlt, string pictureTitle, string description,
            int showOrder, string slug, string keyWords, string metaDescription, string canonicalAddress)
        {
            Name = name;
            if (!string.IsNullOrWhiteSpace(picture))
                Picture = picture;
            Description = description;
            ShowOrder = showOrder;
            Slug = slug;
            KeyWords = keyWords;
            MetaDescription = metaDescription;
            CanonicalAddress = canonicalAddress;
            PictureTitle = pictureTitle;
            PictureAlt = pictureAlt;
        }


    }

}
