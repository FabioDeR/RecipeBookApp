namespace RecipeBook.Application.Features.Varieties.Queries.CommonVM
{
    public class VarietyDetailVM
    {
        public Guid Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public ProductInfoDto ProductInfoDto { get; set; } = default!;
    }
}