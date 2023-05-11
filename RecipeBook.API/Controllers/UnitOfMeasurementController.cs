using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RecipeBook.Application.Features.UnitOfMeasurements.Commands.CreateUnitOfMeasurement;
using RecipeBook.Application.Features.UnitOfMeasurements.Commands.DeleteUnitOfMeasurement;
using RecipeBook.Application.Features.UnitOfMeasurements.Commands.UpdateUnitOfMeasurement;
using RecipeBook.Application.Features.UnitOfMeasurements.Queries.CommonVM;
using RecipeBook.Application.Features.UnitOfMeasurements.Queries.UnitOfMeasurementDetail;
using RecipeBook.Application.Features.UnitOfMeasurements.Queries.UnitOfMeasurementList;
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
    public class UnitOfMeasurementController : ControllerBase
    {
        public readonly IMediator _mediator;

        public UnitOfMeasurementController(IMediator mediator)
        {
            _mediator = mediator;
        }

        //Get All

        [HttpGet]
        public async Task<ActionResult<List<UnitOfMeasurementDetailVM>>> GetAllCut()
        {
            var dtos = await _mediator.Send(new GetUnitOfMeasurementListQuery());
            return Ok(dtos);
        }

        //Post

        [HttpPost(Name = "AddUnitOfMeasurement")]
        public async Task<ActionResult<CreateUnitOfMeasurementResponse>> Create([FromBody] CreateUnitOfMeasurementCommand createUnitOfMeasurementCommand)
        {
            var response = await _mediator.Send(createUnitOfMeasurementCommand);
            return Ok(response);
        }


        //GetById
        [HttpGet("{id}")]
        public async Task<ActionResult<UnitOfMeasurementDetailVM>> GetUnitOfMeasurementDetail(Guid id)
        {
            var getUnitOfMeasurementDetailQuery = new GetUnitOfMeasurementDetailQuery() { Id = id };

            return Ok(await _mediator.Send(getUnitOfMeasurementDetailQuery));
        }

        //Update
        [HttpPut]
        public async Task<ActionResult> UpdateUnitOfMeasurement([FromBody] UpdateUnitOfMeasurementCommand updateUnitOfMeasurement)
        {
            await _mediator.Send(updateUnitOfMeasurement);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteUnitOfMeasurement(Guid id)
        {
            var deletedCommand = new DeleteUnitOfMeasurementCommand() { Id = id };
            await _mediator.Send(deletedCommand);
            return NoContent();

        }
    }
}
