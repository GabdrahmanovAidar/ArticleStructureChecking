using ArticlesStructureChecking.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArticlesStructureChecking.Application.Article.GetArticleReviewsByArticleId
{
    public class GetArticleReviewsByArticleIdResponse
    {
        public int Id { get; set; }
        public EArticleStatus Status { get; set; }
        public string CreatedAt { get; set; }
    }
}
