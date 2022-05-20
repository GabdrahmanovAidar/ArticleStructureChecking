using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArticlesStructureChecking.Application.Article.CreateArticle
{
    public class CreateArticleCommand : IRequest<Unit>
    {
        public string Name { get; set; }
    }
}
