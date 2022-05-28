using ArticlesStructureChecking.Application.Article.CreateArticle;
using ArticlesStructureChecking.Application.Article.GetArticles;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ArticlesStructureChecking.Controllers
{
    [ApiController]
    [Route("api/article")]
    public class ArticleController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ArticleController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [ProducesResponseType(typeof(List<GetArticlesResponse>),StatusCodes.Status200OK)]
        [HttpGet("getList")]
        public async Task<IActionResult> GetList()
        {
            var request = new GetArticlesQuery();
            var response = await _mediator.Send(request);
            return Ok(response);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] CreateArticleCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }
    }
}
