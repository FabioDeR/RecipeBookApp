namespace RecipeBook.Application.Features.Recipes.Commands.CreateRecipe
{
    public class RecipeDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
    }
}