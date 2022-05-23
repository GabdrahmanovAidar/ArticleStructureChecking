using ArticlesStructureChecking.Application.Article.CreateArticle;
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

        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpPost("create")]
        public async Task<IActionResult> Create(CreateArticleCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }
    }
}
