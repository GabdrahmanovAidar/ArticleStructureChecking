using ArticlesStructureChecking.Application.Article.CheckArticleReview;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ArticlesStructureChecking.Controllers
{
    [ApiController]
    [Route("api/articleReview")]
    public class ArticleReviewController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ArticleReviewController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [ProducesResponseType(typeof(CheckArticleReviewResponse), StatusCodes.Status200OK)]
        [HttpPost("check")]
        public async Task<IActionResult> CheckArticleReview(CheckArticleReviewCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }
    }
}
