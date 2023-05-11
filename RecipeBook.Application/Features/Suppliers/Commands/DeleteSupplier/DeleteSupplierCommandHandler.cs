using MediatR;
using RecipeBook.Application.Contracts.Persistence;
using RecipeBook.Application.Exceptions;
using RecipeBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeBook.Application.Features.Suppliers.Commands.DeleteSupplier
{
    public class DeleteSupplierCommandHandler : IRequestHandler<DeleteSupplierCommand>
    {
        public readonly IAsyncRepository<Supplier> _supplierRepository;

        public DeleteSupplierCommandHandler(IAsyncRepository<Supplier> supplierRepository)
        {
            _supplierRepository = supplierRepository;
        }

        public async Task<Unit> Handle(DeleteSupplierCommand request, CancellationToken cancellationToken)
        {
            var deleteSupplier = await _supplierRepository.GetByIdAsync(request.Id);

            if (deleteSupplier == null)
            {
                throw new NotFoundException(nameof(Supplier),request.Id);
            }

            await _supplierRepository.DeleteAsync(deleteSupplier);

            return Unit.Value;
        }
    }
}
