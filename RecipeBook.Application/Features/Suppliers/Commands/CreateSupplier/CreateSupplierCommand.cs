using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeBook.Application.Features.Suppliers.Commands.CreateSupplier
{
    public class CreateSupplierCommand : IRequest<CreateSupplierCommandResponse>
    {
        public string Name { get; set; } = string.Empty;
    }
}
