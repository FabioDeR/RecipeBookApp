using MediatR;
using Microsoft.AspNetCore.Mvc;
using RecipeBook.Application.Features.Categories.Commands.CreateCategory;
using RecipeBook.Application.Features.Categories.Commands.DeleteCategory;
using RecipeBook.Application.Features.Categories.Commands.UpdateCategory;
using RecipeBook.Application.Features.Categories.Queries.CommonVM;
using RecipeBook.Application.Features.Categories.Queries.GetCategoryDetail;
using RecipeBook.Application.Features.Categories.Queries.GetCategoryList;
using RecipeBook.Application.Features.Cultures.Commands.CreateCulture;
using RecipeBook.Application.Features.Cultures.Commands.DeleteCulture;
using RecipeBook.Application.Features.Cultures.Commands.UpdateCulture;
using RecipeBook.Application.Features.Cultures.Queries.CommonVM;
using RecipeBook.Application.Features.Cultures.Queries.CultureDetail;
using RecipeBook.Application.Features.Cultures.Queries.CultureList;

namespace RecipeBook.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CultureController : ControllerBase
    {
        public readonly IMediator _mediator;

        public CultureController(IMediator mediator)
        {
            _mediator = mediator;
        }

        //Get All

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<CultureVM>>> GetAllCutlures()
        {
            var dtos = await _mediator.Send(new GetCultureListQuery());
            return Ok(dtos);
        }

        //Post

        [HttpPost(Name = "AddCulture")]
        public async Task<ActionResult<CreateCultureCommandResponse>> Create([FromBody] CreateCultureCommand createCultureCommand)
        {
            var response = await _mediator.Send(createCultureCommand);
            return Ok(response);
        }


        //GetById
        [HttpGet("{id}")]
        public async Task<ActionResult<CultureVM>> GetCultureDetail(Guid id)
        {
            var getCultureDetailQuery = new GetCultureDetailQuery() { Id = id };

            return Ok(await _mediator.Send(getCultureDetailQuery));
        }

        //Update
        [HttpPut]
        public async Task<ActionResult> UpdateCulture([FromBody] UpdateCultureCommand updateCultureCommand)
        {
            await _mediator.Send(updateCultureCommand);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCulture(Guid id)
        {
            var deletedCommand = new DeleteCultureCommand() { Id = id };
            await _mediator.Send(deletedCommand);
            return NoContent();

        }
    }
}
