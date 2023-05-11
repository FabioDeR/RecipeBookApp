namespace RecipeBook.Application.Features.Products.Queries.ProductDetail
{
    public class ProductDetailVM
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string UnitName { get; set; } = string.Empty;
    }
}