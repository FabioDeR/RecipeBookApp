using MediatR;
using Microsoft.AspNetCore.Mvc;
using RecipeBook.Application.Features.Articles.Commands.CreateArticle;
using RecipeBook.Application.Features.Articles.Commands.DeleteArtcile;
using RecipeBook.Application.Features.Articles.Commands.UpdateArticle;
using RecipeBook.Application.Features.Articles.Queries.ArticleDetail;
using RecipeBook.Application.Features.Articles.Queries.CommonVM;
using RecipeBook.Application.Features.Articles.Queries.GetListArticle;

namespace RecipeBook.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticleController : ControllerBase
    {
        public readonly IMediator _mediator;

        public ArticleController(IMediator mediator)
        {
            _mediator = mediator;
        }


        //Get
        [HttpGet]
        public async Task<ActionResult<List<ArticleWithAllIncludeVM>>> GetAllArticleWithInclude()
        {
            var articleList = await _mediator.Send(new GetListArticleQuery());
            return Ok(articleList);
        }

        //GetById
        [HttpGet("{id}")]
        public async Task<ActionResult<ArticleWithAllIncludeVM>> GetArticleDetail(Guid id)
        {
            var getArticleDetailQuery = new GetArticleDetailQuery() { ArticleId = id };

            return Ok(await _mediator.Send(getArticleDetailQuery));
        }

        [HttpPost]
        public async Task<ActionResult<string>> CreateArticle([FromBody] CreateArtcileCommand article)
        {
            var response = await _mediator.Send(article);

            return Ok(response);
        }


        //Update
        [HttpPut]
        public async Task<ActionResult> UpdateArticle([FromBody] UpdateArticleCommand updateArticleCommand)
        {
            await _mediator.Send(updateArticleCommand);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteArticle(Guid id)
        {
            var deletedCommand = new DeleteArticleCommand() { ArticleId = id };
            await _mediator.Send(deletedCommand);
            return Ok();
        }
    }
}
