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

namespace RecipeBook.Application.Features.UnitOfMeasurements.Commands.UpdateUnitOfMeasurement
{
    public class UpdateUnitOfMeasurementCommandHandler : IRequestHandler<UpdateUnitOfMeasurementCommand>
    {
        public readonly IAsyncRepository<UnitOfMeasurement> _unitOfMeasurmentRepository;
        private readonly IMapper _mapper;
        public UpdateUnitOfMeasurementCommandHandler(IAsyncRepository<UnitOfMeasurement> unitOfMeasurmentRepository, IMapper mapper)
        {
            _unitOfMeasurmentRepository = unitOfMeasurmentRepository;
            _mapper = mapper;
        }
        public async Task<Unit> Handle(UpdateUnitOfMeasurementCommand request, CancellationToken cancellationToken)
        {
            var unitUpdated = await _unitOfMeasurmentRepository.GetByIdAsync(request.Id);

            if (unitUpdated == null)
            {

                throw new NotFoundException(nameof(UnitOfMeasurement), request.Id);

            }
            _mapper.Map(request, unitUpdated);

            await _unitOfMeasurmentRepository.UpdateAsync(unitUpdated);

            return Unit.Value;
        }
    }
}
