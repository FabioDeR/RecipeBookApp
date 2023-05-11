using RecipeBook.Application.Responses;

namespace RecipeBook.Application.Features.Gammes.Commands.CreateGamme
{
    public class CreateGammeCommandReponse : BaseResponse
    {


        public GammeDto GammeDto { get; set; } = default!;
    }
}