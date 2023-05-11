using AutoMapper;
using MediatR;
using RecipeBook.Application.Contracts.Persistence;
using RecipeBook.Application.Features.UnitOfMeasurements.Queries.CommonVM;
using RecipeBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeBook.Application.Features.UnitOfMeasurements.Queries.UnitOfMeasurementList
{
    public class GetUnitOfMeasurementListQueryHandler : IRequestHandler<GetUnitOfMeasurementListQuery, List<UnitOfMeasurementDetailVM>>
    {
        public readonly IAsyncRepository<UnitOfMeasurement> _unitOfMeasurementRepository;
        public readonly IMapper _mapper;

        public GetUnitOfMeasurementListQueryHandler(IAsyncRepository<UnitOfMeasurement> unitOfMeasurementRepository, IMapper mapper)
        {
            _unitOfMeasurementRepository = unitOfMeasurementRepository;
            _mapper = mapper;
        }


        async Task<List<UnitOfMeasurementDetailVM>> IRequestHandler<GetUnitOfMeasurementListQuery, List<UnitOfMeasurementDetailVM>>.Handle(GetUnitOfMeasurementListQuery request, CancellationToken cancellationToken)
        {
            var unitList = await _unitOfMeasurementRepository.ListAllAsync();

            return _mapper.Map<List<UnitOfMeasurementDetailVM>>(unitList);
        }
    }
}
