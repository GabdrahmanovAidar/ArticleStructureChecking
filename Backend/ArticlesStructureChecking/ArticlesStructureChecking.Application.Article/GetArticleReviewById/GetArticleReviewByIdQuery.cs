using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArticlesStructureChecking.Application.Article.GetArticleReviewById
{
    public class GetArticleReviewByIdQuery : IRequest<GetArticleReviewByIdResponse>
    {
        public int Id { get; set; }
    }
}
