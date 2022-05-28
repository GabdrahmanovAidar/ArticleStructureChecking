using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArticlesStructureChecking.Application.Article.GetArticles
{
    public class GetArticlesQuery : IRequest<List<GetArticlesResponse>>
    {

    }
}
