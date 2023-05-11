using RecipeBook.Domain.Entities;

namespace RecipeBook.Application.Features.Ingredients.Queries.IngredientDetail
{
    public class IngredientVM
    {
        public float Quantity { get; set; }
        public Guid RecipeBookId { get; set; }
        public string RecipeBookName { get; set; } = default!;
        public Guid ProductId { get; set; }
        public string ProductName { get; set; } = default!;
        public Guid? VarietyId { get; set; }
        public string VarietyName { get; set; } = default!;
        public Guid UnitIdName { get; set; }
        public string UnitName { get; set; } = default!;
    }
}