using AutoMapper;
using MediatR;
using RecipeBook.Application.Contracts.Persistence;
using RecipeBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeBook.Application.Features.Suppliers.Queries.SupplierList
{
    public class GetSupplierListQueryHandler : IRequestHandler<GetSupplierListQuery, List<SupplierListVM>>
    {
        public readonly IAsyncRepository<Supplier> _supplierRepository;
        public readonly IMapper _mapper;

        public GetSupplierListQueryHandler(IAsyncRepository<Supplier> supplierRepository, IMapper mapper)
        {
            _supplierRepository = supplierRepository;
            _mapper = mapper;
        }

        public async Task<List<SupplierListVM>> Handle(GetSupplierListQuery request, CancellationToken cancellationToken)
        {
            var supplierList = await _supplierRepository.ListAllAsync();

            return _mapper.Map<List<SupplierListVM>>(supplierList);
        }
    }
}
