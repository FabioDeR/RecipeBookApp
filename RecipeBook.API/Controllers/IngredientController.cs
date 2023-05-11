using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RecipeBook.Application.Features.Articles.Commands.CreateArticle;
using RecipeBook.Application.Features.Articles.Commands.DeleteArtcile;
using RecipeBook.Application.Features.Articles.Commands.UpdateArticle;
using RecipeBook.Application.Features.Articles.Queries.ArticleDetail;
using RecipeBook.Application.Features.Articles.Queries.CommonVM;
using RecipeBook.Application.Features.Articles.Queries.GetListArticle;
using RecipeBook.Application.Features.Ingredients.Command.CreateIngredient;
using RecipeBook.Application.Features.Ingredients.Command.DeleteIngredient;
using RecipeBook.Application.Features.Ingredients.Command.UpdateIngredient;
using RecipeBook.Application.Features.Ingredients.Queries.IngredientDetail;
using RecipeBook.Application.Features.Ingredients.Queries.IngredientList;

namespace RecipeBook.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IngredientController : ControllerBase
    {
        public readonly IMediator _mediator;

        public IngredientController(IMediator mediator)
        {
            _mediator = mediator;
        }


        //Get
        [HttpGet]
        public async Task<ActionResult<List<IngredientListByRecipeBookVM>>> GetIngredientListByRecipeBook()
        {
            var articleList = await _mediator.Send(new GetIngredientListByRecipeBookQuery());
            return Ok(articleList);
        }

        //GetById
        [HttpGet("{id}")]
        public async Task<ActionResult<IngredientVM>> GetIngredientDetail(Guid id)
        {
            var getIngredientDetail = new GetIngredientDetailQuery() { Id = id };

            return Ok(await _mediator.Send(getIngredientDetail));
        }

        [HttpPost]
        public async Task<ActionResult<string>> CreateIngredient([FromBody] CreateIngredientCommand ingredient)
        {
            var response = await _mediator.Send(ingredient);

            return Ok(response);
        }


        //Update
        [HttpPut]
        public async Task<ActionResult> UpdateIngredient([FromBody] UpdateIngredientCommand updateIngredientCommand)
        {
            await _mediator.Send(updateIngredientCommand);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteIngredient(Guid id)
        {
            var deletedCommand = new DeleteIngredientCommand() { Id = id };
            await _mediator.Send(deletedCommand);
            return Ok();
        }
    }
}
