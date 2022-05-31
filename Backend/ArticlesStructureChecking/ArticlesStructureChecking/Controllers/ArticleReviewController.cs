using ArticlesStructureChecking.Application.Article.CheckArticleReview;
using ArticlesStructureChecking.Application.Article.CreateArticleReview;
using ArticlesStructureChecking.Application.Article.GetArticleReviewById;
using ArticlesStructureChecking.Application.Article.GetArticleReviewsByArticleId;
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

        [ProducesResponseType(typeof(GetArticleReviewByIdResponse), StatusCodes.Status200OK)]
        [HttpGet("get/{id}")]
        public async Task<IActionResult> GetById([FromRoute] GetArticleReviewByIdQuery query)
        {
            var response = await _mediator.Send(query);
            return Ok(response);
        }

        [ProducesResponseType(typeof(List<GetArticleReviewsByArticleIdResponse>), StatusCodes.Status200OK)]
        [HttpGet("getByArticleId")]
        public async Task<IActionResult> GetByArticleId([FromQuery] GetArticleReviewsByArticleIdQuery query)
        {
            var response = await _mediator.Send(query);
            return Ok(response);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpPost("create")]
        public async Task<IActionResult> Create([FromForm] CreateArticleReviewCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        [ProducesResponseType(typeof(CheckArticleReviewResponse), StatusCodes.Status200OK)]
        [HttpPost("check")]
        public async Task<IActionResult> Check([FromBody] CheckArticleReviewCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }
    }
}
