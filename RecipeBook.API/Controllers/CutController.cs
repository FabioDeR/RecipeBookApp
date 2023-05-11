using MediatR;
using Microsoft.AspNetCore.Mvc;
using RecipeBook.Application.Features.Cultures.Commands.CreateCulture;
using RecipeBook.Application.Features.Cultures.Commands.DeleteCulture;
using RecipeBook.Application.Features.Cultures.Commands.UpdateCulture;
using RecipeBook.Application.Features.Cultures.Queries.CommonVM;
using RecipeBook.Application.Features.Cuts.Commands.CreateCut;
using RecipeBook.Application.Features.Cuts.Commands.DeleteCut;
using RecipeBook.Application.Features.Cuts.Commands.UpdateCut;
using RecipeBook.Application.Features.Cuts.Queries.CommonVM;
using RecipeBook.Application.Features.Cuts.Queries.CutDetail;
using RecipeBook.Application.Features.Cuts.Queries.CutList;
using RecipeBook.Domain.Entities;

namespace RecipeBook.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CutController : ControllerBase
    {
        public readonly IMediator _mediator;

        public CutController(IMediator mediator)
        {
            _mediator = mediator;
        }

        //Get All

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<CutVM>>> GetAllCut()
        {
            var dtos = await _mediator.Send(new GetCutListQuery());
            return Ok(dtos);
        }

        //Post

        [HttpPost(Name = "AddCut")]
        public async Task<ActionResult<CreateCutCommand>> Create([FromBody] CreateCutCommand createCutCommand)
        {
            var response = await _mediator.Send(createCutCommand);
            return Ok(response);
        }


        //GetById
        [HttpGet("{id}")]
        public async Task<ActionResult<CutVM>> GetCutDetail(Guid id)
        {
            var getCutDetailQuery = new GetCutDetailCommand() { Id = id };

            return Ok(await _mediator.Send(getCutDetailQuery));
        }

        //Update
        [HttpPut]
        public async Task<ActionResult> UpdateCut([FromBody] UpdateCutCommand updateCutCommand)
        {
            await _mediator.Send(updateCutCommand);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCut(Guid id)
        {
            var deletedCommand = new DeleteCutCommand() { Id = id };
            await _mediator.Send(deletedCommand);
            return NoContent();

        }



    }
}
