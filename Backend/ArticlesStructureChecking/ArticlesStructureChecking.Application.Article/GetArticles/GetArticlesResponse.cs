using ArticlesStructureChecking.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArticlesStructureChecking.Application.Article.GetArticles
{
    public class GetArticlesResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CheckCount { get; set; }
        public EArticleStatus Status { get; set; }
    }
}
