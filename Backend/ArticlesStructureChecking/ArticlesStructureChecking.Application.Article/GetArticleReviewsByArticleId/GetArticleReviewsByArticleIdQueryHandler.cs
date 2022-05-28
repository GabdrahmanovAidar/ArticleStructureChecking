using ArticlesStructureChecking.Domain.Entities.Article;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArticlesStructureChecking.Application.Article.GetArticleReviewsByArticleId
{
    public class GetArticleReviewsByArticleIdQueryHandler : IRequestHandler<GetArticleReviewsByArticleIdQuery, List<GetArticleReviewsByArticleIdResponse>>
    {
        private readonly DbContext _db;
        private readonly IMapper _mapper;
        public GetArticleReviewsByArticleIdQueryHandler(DbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<List<GetArticleReviewsByArticleIdResponse>> Handle(GetArticleReviewsByArticleIdQuery query, CancellationToken cancellationToken)
        {
            var articleReviews = await _db.Set<ArticleReviewEntity>().Where(x => x.ArticleId == query.ArticleId).ProjectTo<GetArticleReviewsByArticleIdResponse>(_mapper.ConfigurationProvider).ToListAsync();
            return articleReviews;
        }
    }
}
