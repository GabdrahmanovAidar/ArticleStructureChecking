using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArticlesStructureChecking.Application.Article.CreateArticleReview
{
    public class CreateArticleReviewCommand : IRequest<Unit>
    {
        public int ArticleId { get; set; }
        public IFormFile FormFile { get; set; }
    }
}
