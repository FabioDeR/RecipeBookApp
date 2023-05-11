using AutoMapper;
using MediatR;
using RecipeBook.Application.Contracts.Persistence;
using RecipeBook.Application.Exceptions;
using RecipeBook.Application.Features.UnitOfMeasurements.Queries.CommonVM;
using RecipeBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeBook.Application.Features.UnitOfMeasurements.Queries.UnitOfMeasurementDetail
{
    public class GetUnitOfMeasurementDetailQueryHandler : IRequestHandler<GetUnitOfMeasurementDetailQuery, UnitOfMeasurementDetailVM>
    {
        public readonly IAsyncRepository<UnitOfMeasurement> _unitOfMeasurementRepository;
        public readonly IMapper _mapper;

        public GetUnitOfMeasurementDetailQueryHandler(IAsyncRepository<UnitOfMeasurement> unitOfMeasurementRepository, IMapper mapper)
        {
            _unitOfMeasurementRepository = unitOfMeasurementRepository;
            _mapper = mapper;
        }

        public async Task<UnitOfMeasurementDetailVM> Handle(GetUnitOfMeasurementDetailQuery request, CancellationToken cancellationToken)
        {
            var unitOfMeasurement = await _unitOfMeasurementRepository.GetByIdAsync(request.Id);
            if (unitOfMeasurement == null)
            {

                throw new NotFoundException(nameof(UnitOfMeasurement), request.Id);

            }
            return _mapper.Map<UnitOfMeasurementDetailVM>(unitOfMeasurement);
        }
    }
}
