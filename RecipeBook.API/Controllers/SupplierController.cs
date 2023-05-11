using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RecipeBook.Application.Features.Suppliers.Commands.CreateSupplier;
using RecipeBook.Application.Features.Suppliers.Commands.DeleteSupplier;
using RecipeBook.Application.Features.Suppliers.Commands.UpdateSupplier;
using RecipeBook.Application.Features.Suppliers.Queries.SupplierDetail;
using RecipeBook.Application.Features.Suppliers.Queries.SupplierList;
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
    public class SupplierController : ControllerBase
    {
        public readonly IMediator _mediator;

        public SupplierController(IMediator mediator)
        {
            _mediator = mediator;
        }

        //Get All

        [HttpGet]
        public async Task<ActionResult<List<SupplierListVM>>> GetAllCut()
        {
            var dtos = await _mediator.Send(new GetSupplierListQuery());
            return Ok(dtos);
        }

        //Post

        [HttpPost(Name = "AddSupplier")]
        public async Task<ActionResult<CreateSupplierCommandResponse>> Create([FromBody] CreateSupplierCommand createSupplierCommand)
        {
            var response = await _mediator.Send(createSupplierCommand);
            return Ok(response);
        }


        //GetById
        [HttpGet("{id}")]
        public async Task<ActionResult<SupplierDetailVM>> GetSuppplierDetail(Guid id)
        {
            var getSupplierDetailQuery = new GetSupplierDetailQuery() { Id = id };

            return Ok(await _mediator.Send(getSupplierDetailQuery));
        }

        //Update
        [HttpPut]
        public async Task<ActionResult> UpdateSupplier([FromBody] UpdateSupplierCommand updateSupplierCommand)
        {
            await _mediator.Send(updateSupplierCommand);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteSupplier(Guid id)
        {
            var deletedCommand = new DeleteSupplierCommand() { Id = id };
            await _mediator.Send(deletedCommand);
            return NoContent();

        }
    }
}
