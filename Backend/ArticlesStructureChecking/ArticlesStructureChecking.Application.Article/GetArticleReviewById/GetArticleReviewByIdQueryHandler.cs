using ArticlesStructureChecking.Domain.Entities.Article;
using ArticlesStructureChecking.Exceptions;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArticlesStructureChecking.Application.Article.GetArticleReviewById
{
    public class GetArticleReviewByIdQueryHandler : IRequestHandler<GetArticleReviewByIdQuery, GetArticleReviewByIdResponse>
    {
        private readonly DbContext _db;
        private readonly IMapper _mapper;
        public GetArticleReviewByIdQueryHandler(DbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }
        public async Task<GetArticleReviewByIdResponse> Handle(GetArticleReviewByIdQuery request, CancellationToken cancellationToken)
        {
            var article = await _db.Set<ArticleReviewEntity>().FirstOrDefaultAsync(x => x.Id == request.Id);
            if (article == null)
                throw new NotFoundException("Article not found");
            return new GetArticleReviewByIdResponse() { FilePath = article.FilePath, Status = article.Status, Errors = article.Errors };
        }
    }
}
