using ArticlesStructureChecking.Application.Article.GetArticleReviewsByArticleId;
using ArticlesStructureChecking.Application.Article.GetArticles;
using ArticlesStructureChecking.Domain.Entities.Article;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArticlesStructureChecking.Application.Article
{
    public class ArticleProfile : Profile
    {
        public ArticleProfile()
        {
            CreateMap<ArticleEntity, GetArticlesResponse>();

            CreateMap<ArticleReviewEntity, GetArticleReviewsByArticleIdResponse>();
        }
    }
}
