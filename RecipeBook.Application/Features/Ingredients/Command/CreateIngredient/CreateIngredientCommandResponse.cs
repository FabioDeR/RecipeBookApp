using RecipeBook.Application.Responses;

namespace RecipeBook.Application.Features.Ingredients.Command.CreateIngredient
{
    public class CreateIngredientCommandResponse : BaseResponse
    {
        public IngredientDto IngredientDto { get; set; } = default!;
    }
}