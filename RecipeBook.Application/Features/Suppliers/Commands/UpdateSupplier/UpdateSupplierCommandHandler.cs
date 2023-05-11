using AutoMapper;
using MediatR;
using RecipeBook.Application.Contracts.Persistence;
using RecipeBook.Application.Exceptions;
using RecipeBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeBook.Application.Features.Suppliers.Commands.UpdateSupplier
{
    public class UpdateSupplierCommandHandler : IRequestHandler<UpdateSupplierCommand>
    {
        public readonly IAsyncRepository<Supplier> _supplierRepository;
        public readonly IMapper _mapper;

        public UpdateSupplierCommandHandler(IAsyncRepository<Supplier> supplierRepository, IMapper mapper)
        {
            _supplierRepository = supplierRepository;
            _mapper = mapper;
        }
        public async Task<Unit> Handle(UpdateSupplierCommand request, CancellationToken cancellationToken)
        {
            var updateSupplier = await _supplierRepository.GetByIdAsync(request.Id);

            if (updateSupplier == null)
            {
                throw new NotFoundException(nameof(Supplier), request.Id);
            }

            _mapper.Map(request, updateSupplier);

            await _supplierRepository.UpdateAsync(updateSupplier);

            return Unit.Value;
        }
    }
}
