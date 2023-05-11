using MediatR;
using Microsoft.AspNetCore.Mvc;
using RecipeBook.Application.Features.Gammes.Commands.CreateGamme;
using RecipeBook.Application.Features.Gammes.Commands.DeleteGamme;
using RecipeBook.Application.Features.Gammes.Commands.UpdateGamme;
using RecipeBook.Application.Features.Gammes.Queries.CommonVM;
using RecipeBook.Application.Features.Gammes.Queries.GammeDetail;
using RecipeBook.Application.Features.Gammes.Queries.GammeList;
using RecipeBook.Domain.Entities;

namespace RecipeBook.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GammeController : Controller
    {
        public readonly IMediator _mediator;

        public GammeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        //Get All

        [HttpGet]    
        public async Task<ActionResult<List<GammeVM>>> GetAllGamme()
        {
            var dtos = await _mediator.Send(new GetGammeListQuery());
            return Ok(dtos);
        }

        //Post

        [HttpPost(Name = "AddGamme")]
        public async Task<ActionResult<CreateGammeCommandReponse>> Create([FromBody] CreateGammeCommand createGammeCommand)
        {
            var response = await _mediator.Send(createGammeCommand);
            return Ok(response);
        }


        //GetById
        [HttpGet("{id}")]
        public async Task<ActionResult<GammeVM>> GetGammeDetail(Guid id)
        {
            var getGammeDetailQuery = new GetGammeDetailQuery() { Id = id };

            return Ok(await _mediator.Send(getGammeDetailQuery));
        }

        //Update
        [HttpPut]
        public async Task<ActionResult> UpdateGamme([FromBody] UpdateGammeCommand updateGammeCommand)
        {
            await _mediator.Send(updateGammeCommand);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteGamme(Guid id)
        {
            var deletedCommand = new DeleteGammeCommand() { Id = id };
            await _mediator.Send(deletedCommand);
            return NoContent();

        }
    }
}
