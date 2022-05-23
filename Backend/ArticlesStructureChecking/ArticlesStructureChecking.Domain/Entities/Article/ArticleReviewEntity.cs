using ArticlesStructureChecking.Domain.Base;

namespace ArticlesStructureChecking.Domain.Entities.Article
{
    public class ArticleReviewEntity : EntityBase
    {
        protected ArticleReviewEntity()
        {

        }

        public ArticleReviewEntity(int articleId, string path)
        {
            ArticleId = articleId;
            FilePath = path;
        }

        public int ArticleId { get; set; }
        public virtual ArticleEntity Article { get; set; }
        public string FilePath { get; set; }
        public List<string>? Errors { get; set; }
    }
}
