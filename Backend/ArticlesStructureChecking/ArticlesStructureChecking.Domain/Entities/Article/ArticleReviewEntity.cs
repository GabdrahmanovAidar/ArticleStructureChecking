using ArticlesStructureChecking.Domain.Base;
using ArticlesStructureChecking.Domain.Enums;

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
            Status = EArticleStatus.Pending;
        }

        public int ArticleId { get; set; }
        public virtual ArticleEntity Article { get; set; }
        public EArticleStatus Status { get; set; }
        public string FilePath { get; set; }    
        public List<string>? Errors { get; set; }
    }
}
