using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArticlesStructureChecking.Application.Article.GetArticleReviewsByArticleId
{
    public class GetArticleReviewsByArticleIdQuery : IRequest<List<GetArticleReviewsByArticleIdResponse>>
    {
        public int ArticleId { get; set; }
    }
}
