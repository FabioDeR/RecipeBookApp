using RecipeBook.Application.Responses;

namespace RecipeBook.Application.Features.Suppliers.Commands.CreateSupplier
{
    public class CreateSupplierCommandResponse : BaseResponse
    {


        public SupplierDto SupplierDto { get; set; } = default!;
    }
}