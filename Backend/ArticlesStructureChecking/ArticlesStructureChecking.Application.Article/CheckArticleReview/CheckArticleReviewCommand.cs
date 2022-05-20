using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArticlesStructureChecking.Application.Article.CheckArticleReview
{
    public class CheckArticleReviewCommand : IRequest<CheckArticleReviewResponse>
    {
        public int ArticleReviewId { get; set; }
    }
}
