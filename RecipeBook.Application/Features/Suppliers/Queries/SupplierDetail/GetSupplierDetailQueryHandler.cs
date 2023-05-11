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

namespace RecipeBook.Application.Features.Suppliers.Queries.SupplierDetail
{
    public class GetSupplierDetailQueryHandler : IRequestHandler<GetSupplierDetailQuery, SupplierDetailVM>
    {
        public readonly IAsyncRepository<Supplier> _supplierRepository;
        public readonly IMapper _mapper;

        public GetSupplierDetailQueryHandler(IAsyncRepository<Supplier> supplierRepository, IMapper mapper)
        {
            _supplierRepository = supplierRepository;
            _mapper = mapper;
        }

        public async Task<SupplierDetailVM> Handle(GetSupplierDetailQuery request, CancellationToken cancellationToken)
        {
            var supplierDetail = await _supplierRepository.GetByIdAsync(request.Id);

            if (supplierDetail == null)
            {
                throw new NotFoundException(nameof(Supplier), request.Id);
            }

            return _mapper.Map<SupplierDetailVM>(supplierDetail);

        }
    }
}
