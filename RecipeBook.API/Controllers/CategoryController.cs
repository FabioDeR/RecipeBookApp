using MediatR;
using Microsoft.AspNetCore.Mvc;
using RecipeBook.Application.Features.Articles.Commands.DeleteArtcile;
using RecipeBook.Application.Features.Articles.Commands.UpdateArticle;
using RecipeBook.Application.Features.Articles.Queries.ArticleDetail;
using RecipeBook.Application.Features.Articles.Queries.CommonVM;
using RecipeBook.Application.Features.Categories.Commands.CreateCategory;
using RecipeBook.Application.Features.Categories.Commands.DeleteCategory;
using RecipeBook.Application.Features.Categories.Commands.UpdateCategory;
using RecipeBook.Application.Features.Categories.Queries.CommonVM;
using RecipeBook.Application.Features.Categories.Queries.GetCategoryDetail;
using RecipeBook.Application.Features.Categories.Queries.GetCategoryList;

namespace RecipeBook.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IMediator _mediator;


        public CategoryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        //Get All

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<CategoryVM>>> GetAllCategories()
        {
            var dtos = await _mediator.Send(new GetListCategoryQuery());
            return Ok(dtos);
        }

        //Post

        [HttpPost(Name = "AddCategory")]
        public async Task<ActionResult<CreateCategoryCommandResponse>> Create([FromBody] CreateCategoryCommand createCategoryCommand)
        {
            var response = await _mediator.Send(createCategoryCommand);
            return Ok(response);
        }


        //GetById
        [HttpGet("{id}")]
        public async Task<ActionResult<CategoryVM>> GetCategoryDetail(Guid id)
        {
            var getCategoryDetailQuery = new GetCategoryDetailQuery() { Id = id };

            return Ok(await _mediator.Send(getCategoryDetailQuery));
        }

        //Update
        [HttpPut]
        public async Task<ActionResult> UpdateCategory([FromBody] UpdateCategoryCommand updateCategoryCommand)
        {
            await _mediator.Send(updateCategoryCommand);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCategory(Guid id)
        {
            var deletedCommand = new DeleteCategoryCommand() { CategoryId = id };            
            await _mediator.Send(deletedCommand);
            return Ok();

        }

    }
}
