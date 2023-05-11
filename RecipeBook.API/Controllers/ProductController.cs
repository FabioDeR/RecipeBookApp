using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RecipeBook.Application.Features.Gammes.Commands.CreateGamme;
using RecipeBook.Application.Features.Gammes.Commands.DeleteGamme;
using RecipeBook.Application.Features.Gammes.Commands.UpdateGamme;
using RecipeBook.Application.Features.Gammes.Queries.CommonVM;
using RecipeBook.Application.Features.Gammes.Queries.GammeDetail;
using RecipeBook.Application.Features.Gammes.Queries.GammeList;
using RecipeBook.Application.Features.Products.Commands.CreateProduct;
using RecipeBook.Application.Features.Products.Commands.DeleteProduct;
using RecipeBook.Application.Features.Products.Commands.UpdateProduct;
using RecipeBook.Application.Features.Products.Queries.ProductDetail;
using RecipeBook.Application.Features.Products.Queries.ProductList;

namespace RecipeBook.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        public readonly IMediator _mediator;

        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }

        //Get All

        [HttpGet]
        public async Task<ActionResult<List<ProductListWithUnitVM>>> GetAllProduct()
        {
            var dtos = await _mediator.Send(new GetProductListQuery());
            return Ok(dtos);
        }

        //Post

        [HttpPost(Name = "AddProduct")]
        public async Task<ActionResult<CreateProductCommandResponse>> Create([FromBody] CreateProductCommand createProductCommand)
        {
            var response = await _mediator.Send(createProductCommand);
            return Ok(response);
        }


        //GetById
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDetailVM>> GetProductDetail(Guid id)
        {
            var getProductDetailQuery = new GetProductDetailQuery() { Id = id };

            return Ok(await _mediator.Send(getProductDetailQuery));
        }

        //Update
        [HttpPut]
        public async Task<ActionResult> UpdateGamme([FromBody] UpdateProductCommand updateProductCommand)
        {
            await _mediator.Send(updateProductCommand);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteProduct(Guid id)
        {
            var deletedCommand = new DeleteProductCommand() { Id = id };
            await _mediator.Send(deletedCommand);
            return NoContent();

        }
    }
}
