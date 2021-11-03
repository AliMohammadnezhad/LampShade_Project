using System.Collections.Generic;
using _01_LampShadeQueries.Contracts.Comment;

namespace _01_LampShadeQueries.Contracts.Article
{
    public class ArticleQueryModel
    {
        public string Title { get; set; }
        public string ShortDescription { get; set; }
        public string Description { get; set; }
        public string Picture { get; set; }
        public string PictureAlt { get; set; }
        public string PictureTitle { get; set; }
        public string PublishDate { get; set; }
        public string Slug { get; set; }
        public string KeyWords { get; set; }
        public string MetaDescription { get; set; }
        public string CanonicalAddress { get; set; }
        public long CategoryId { get; set; }
        public string CategorySlug { get; set; }
        public string Category { get; set; }
        public long Id { get; set; }
        public string MonthName { get; set; }
        public string StableDate { get; set; }
        public List<CommentQueryModel> Comments { get; set; }
    }
}
