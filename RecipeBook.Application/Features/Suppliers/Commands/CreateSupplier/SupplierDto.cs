namespace RecipeBook.Application.Features.Suppliers.Commands.CreateSupplier
{
    public class SupplierDto
    {
        public Guid Id { get; set; }

        public string Name { get; set; } = string.Empty;
    }
}