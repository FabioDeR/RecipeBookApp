using RecipeBook.Application.Responses;

namespace RecipeBook.Application.Features.Recipes.Commands.CreateRecipe
{
    public class CreateRecipeCommandResponse : BaseResponse
    {
        public RecipeDto RecipeBookDto { get; set; } = default!;
    }
}