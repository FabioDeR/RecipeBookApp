using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeBook.Application.Features.Suppliers.Commands.UpdateSupplier
{
    public class UpdateSupplierCommand : IRequest
    {
        public Guid Id { get; set; }

        public string Name { get; set; } = string.Empty;
    }
}
