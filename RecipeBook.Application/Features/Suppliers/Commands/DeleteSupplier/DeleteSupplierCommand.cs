using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeBook.Application.Features.Suppliers.Commands.DeleteSupplier
{
    public class DeleteSupplierCommand : IRequest
    {
        public Guid Id { get; set; }
    }
}
