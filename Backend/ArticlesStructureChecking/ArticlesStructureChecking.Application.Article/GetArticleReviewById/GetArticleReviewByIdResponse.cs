using ArticlesStructureChecking.Domain.Enums;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArticlesStructureChecking.Application.Article.GetArticleReviewById
{
    public class GetArticleReviewByIdResponse
    {
        public EArticleStatus Status { get; set; }
        public string FilePath { get; set; }
        public List<string> Errors { get; set; }
    }
}
