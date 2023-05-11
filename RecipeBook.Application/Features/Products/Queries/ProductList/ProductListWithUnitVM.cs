namespace RecipeBook.Application.Features.Products.Queries.ProductList
{
    public class ProductListWithUnitVM
    {
        public Guid Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string UnitName { get; set; } = string.Empty;
    }
}