using MediatR;
using RecipeBook.Application.Contracts.Persistence;
using RecipeBook.Application.Exceptions;
using RecipeBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeBook.Application.Features.UnitOfMeasurements.Commands.DeleteUnitOfMeasurement
{
    public class DeleteUnitOfMeasurementCommandHandler : IRequestHandler<DeleteUnitOfMeasurementCommand>
    {
        public readonly IAsyncRepository<UnitOfMeasurement> _unitOfMeasurmentRepository;

        public DeleteUnitOfMeasurementCommandHandler(IAsyncRepository<UnitOfMeasurement> unitOfMeasurmentRepository)
        {
            _unitOfMeasurmentRepository = unitOfMeasurmentRepository;
        }
        public async Task<Unit> Handle(DeleteUnitOfMeasurementCommand request, CancellationToken cancellationToken)
        {
            var unitDeleted = await _unitOfMeasurmentRepository.GetByIdAsync(request.Id);            

            if (unitDeleted == null)
            {
                throw new NotFoundException(nameof(UnitOfMeasurement), request.Id);
            }

            await _unitOfMeasurmentRepository.DeleteAsync(unitDeleted);

            return Unit.Value;
        }
    }
}
