using RecipeBook.Application.Features.Categories.Commands.CreateCategory;
using RecipeBook.Application.Responses;

namespace RecipeBook.Application.Features.Cuts.Commands.CreateCut
{
    public class CreateCutCommandResponse : BaseResponse
    {

        public CutDto CutDto { get; set; } = default!;
    }
}