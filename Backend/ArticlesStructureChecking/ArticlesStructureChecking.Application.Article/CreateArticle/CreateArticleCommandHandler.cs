using ArticlesStructureChecking.Domain.Entities.Article;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArticlesStructureChecking.Application.Article.CreateArticle
{
    public class CreateArticleCommandHandler : IRequestHandler<CreateArticleCommand, Unit>
    {
        private readonly DbContext _db;
        public CreateArticleCommandHandler(DbContext db)
        {
            _db = db;
        }

        public async Task<Unit> Handle(CreateArticleCommand request, CancellationToken cancellationToken)
        {
            var article = new ArticleEntity(request.Name);
            await _db.Set<ArticleEntity>().AddAsync(article);
            await _db.SaveChangesAsync();
            return Unit.Value;
        }
    }
}
