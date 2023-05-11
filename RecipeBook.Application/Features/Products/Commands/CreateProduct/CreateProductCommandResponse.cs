using RecipeBook.Application.Responses;

namespace RecipeBook.Application.Features.Products.Commands.CreateProduct
{
    public class CreateProductCommandResponse : BaseResponse
    {
        public CreateProductCommandResponse() { }

        public ProductDto ProductDto { get; set; } = default!;
    }
}