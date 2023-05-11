using RecipeBook.Application.Features.Varieties.Commands.CreateVariety;

namespace RecipeBook.Application.Features.Products.Commands.CreateProduct
{
    public class ProductDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public Guid UnitId { get; set; }
    }
}