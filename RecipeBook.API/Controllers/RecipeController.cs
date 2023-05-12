using MediatR;
using Microsoft.AspNetCore.Mvc;
using RecipeBook.Application.Features.Gammes.Queries.CommonVM;
using RecipeBook.Application.Features.Gammes.Queries.GammeDetail;
using RecipeBook.Application.Features.RecipeBooks.Commands.UpdateRecipe;
using RecipeBook.Application.Features.Recipes.Commands.CreateRecipe;
using RecipeBook.Application.Features.Recipes.Commands.DeleteRecipe;
using RecipeBook.Application.Features.Recipes.Queries.CommonVM;
using RecipeBook.Application.Features.Recipes.Queries.GetListRecipe;
using RecipeBook.Application.Features.Recipes.Queries.GetRecipeDetail;

namespace RecipeBook.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecipeController : ControllerBase
    {

        private readonly IMediator _mediator;
        
        
        public RecipeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost(Name = "AddRecipeBook")]
        public async Task<ActionResult<CreateRecipeCommandResponse>> CreateRecipeBook([FromBody] CreateRecipeCommand createRecipeBookCommand)
        {
            
            var response = await _mediator.Send(createRecipeBookCommand);
            return Ok(response);
        }


        [HttpGet]
        public async Task<ActionResult<List<RecipeVM>>> GetAllRecipeBook()
        {
            var result = await _mediator.Send(new GetListRecipeQuery());
            return Ok(result);
        }

        //GetById
        [HttpGet("{id}")]
        public async Task<ActionResult<RecipeVM>> GetRecipeDetail(Guid id)
        {
            var getRecipeDetailQuery = new GetRecipeDetailQuery() { Id = id };
            var result = await _mediator.Send(getRecipeDetailQuery);
            return Ok(result);
        }

        //Update
        [HttpPut]
        public async Task<ActionResult> UpdateRecipeBook([FromBody] UpdateRecipeCommand updateRecipeCommand)
        {
            await _mediator.Send(updateRecipeCommand);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteGamme(Guid id)
        {
            var deletedCommand = new DeleteRecipeCommand() { Id = id };
            await _mediator.Send(deletedCommand);
            return NoContent();

        }
    }
}
