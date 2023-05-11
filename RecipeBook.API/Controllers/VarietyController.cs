using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RecipeBook.Application.Features.Gammes.Commands.CreateGamme;
using RecipeBook.Application.Features.Gammes.Commands.DeleteGamme;
using RecipeBook.Application.Features.Gammes.Commands.UpdateGamme;
using RecipeBook.Application.Features.Gammes.Queries.CommonVM;
using RecipeBook.Application.Features.Gammes.Queries.GammeDetail;
using RecipeBook.Application.Features.Gammes.Queries.GammeList;
using RecipeBook.Application.Features.Varieties.Commands.CreateVariety;
using RecipeBook.Application.Features.Varieties.Commands.DeleteVariety;
using RecipeBook.Application.Features.Varieties.Commands.UpdateVariety;
using RecipeBook.Application.Features.Varieties.Queries.CommonVM;
using RecipeBook.Application.Features.Varieties.Queries.VarietyDetail;
using RecipeBook.Application.Features.Varieties.Queries.VarietyList;

namespace RecipeBook.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VarietyController : ControllerBase
    {
        public readonly IMediator _mediator;

        public VarietyController(IMediator mediator)
        {
            _mediator = mediator;
        }

        //Get All

        [HttpGet]
        public async Task<ActionResult<List<VarietyDetailVM>>> GetAllCut()
        {
            var dtos = await _mediator.Send(new GetVarietyListQuery());
            return Ok(dtos);
        }

        //Post

        [HttpPost(Name = "AddVariety")]
        public async Task<ActionResult<CreateVarietyCommand>> Create([FromBody] CreateVarietyCommand createVarietyCommand)
        {
            var response = await _mediator.Send(createVarietyCommand);
            return Ok(response);
        }


        //GetById
        [HttpGet("{id}")]
        public async Task<ActionResult<VarietyDetailVM>> GetVarietyDetail(Guid id)
        {
            var getVarietyDetailQuery = new GetVarietyDetailQuery() { Id = id };

            return Ok(await _mediator.Send(getVarietyDetailQuery));
        }

        //Update
        [HttpPut]
        public async Task<ActionResult> UpdateVariety([FromBody] UpdateVarietyCommand updateVarietyCommand)
        {
            await _mediator.Send(updateVarietyCommand);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteVariety(Guid id)
        {
            var deletedCommand = new DeleteVarietyCommand() { Id = id };
            await _mediator.Send(deletedCommand);
            return Ok();

        }
    }
}
