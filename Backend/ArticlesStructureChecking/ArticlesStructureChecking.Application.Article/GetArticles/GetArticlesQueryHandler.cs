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

namespace ArticlesStructureChecking.Application.Article.GetArticles
{
    public class GetArticlesQueryHandler : IRequestHandler<GetArticlesQuery, List<GetArticlesResponse>>
    {
        private readonly DbContext _db;
        private readonly IMapper _mapper;

        public GetArticlesQueryHandler(DbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<List<GetArticlesResponse>> Handle(GetArticlesQuery request, CancellationToken cancellationToken)
        {
            var articles = await _db.Set<ArticleEntity>().ProjectTo<GetArticlesResponse>(_mapper.ConfigurationProvider).ToListAsync();
            return articles;
        }
    }
}
