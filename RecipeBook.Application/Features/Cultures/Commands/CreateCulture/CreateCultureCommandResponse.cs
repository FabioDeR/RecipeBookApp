using RecipeBook.Application.Responses;

namespace RecipeBook.Application.Features.Cultures.Commands.CreateCulture
{
    public class CreateCultureCommandResponse : BaseResponse
    {


        public CultureDto CultureDto { get; set; } = default!;
    }
}