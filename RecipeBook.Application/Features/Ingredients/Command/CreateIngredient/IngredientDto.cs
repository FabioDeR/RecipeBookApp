namespace RecipeBook.Application.Features.Ingredients.Command.CreateIngredient
{
    public class IngredientDto
    {
        public Guid Id { get; set; }

        public string Name { get; set; } = string.Empty;
    }
}