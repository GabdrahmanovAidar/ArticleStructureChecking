using ArticlesStructureChecking.Domain.Base;
using ArticlesStructureChecking.Domain.Enums;

namespace ArticlesStructureChecking.Domain.Entities.Article
{
    public class ArticleEntity : EntityBase
    {
        protected ArticleEntity()
        {

        }

        public ArticleEntity(string name)
        {
            Name = name;
            CheckCount = 0;
            Status = EArticleStatus.Pending;
        }

        public string Name { get; set; }
        public int UserId { get; set; }
        public virtual User.User User { get; set; }
        public int CheckCount { get; set; }
        public EArticleStatus Status { get; set; }  
    }
}
