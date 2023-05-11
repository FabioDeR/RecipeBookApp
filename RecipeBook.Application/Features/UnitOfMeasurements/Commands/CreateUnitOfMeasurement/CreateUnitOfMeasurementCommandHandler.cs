using AutoMapper;
using MediatR;
using RecipeBook.Application.Contracts.Persistence;
using RecipeBook.Application.Features.Gammes.Commands.CreateGamme;
using RecipeBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeBook.Application.Features.UnitOfMeasurements.Commands.CreateUnitOfMeasurement
{
    public class CreateUnitOfMeasurementCommandHandler : IRequestHandler<CreateUnitOfMeasurementCommand, CreateUnitOfMeasurementResponse>
    {
        public readonly IAsyncRepository<UnitOfMeasurement> _unitOfMeasurmentRepository;
        public readonly IMapper _mapper;

        public CreateUnitOfMeasurementCommandHandler(IAsyncRepository<UnitOfMeasurement> unitOfMeasurmentRepository, IMapper mapper)
        {
            _unitOfMeasurmentRepository = unitOfMeasurmentRepository;
            _mapper = mapper;
        }
        public async Task<CreateUnitOfMeasurementResponse> Handle(CreateUnitOfMeasurementCommand request, CancellationToken cancellationToken)
        {
            var createUnitOfMeasurementResponse = new CreateUnitOfMeasurementResponse();
            var createUnitOfMeasurementValidator = new CreateUnitOfMeasurementValidator();

            var resultUnitOfMeasurementValidator = await createUnitOfMeasurementValidator.ValidateAsync(request);

            if (resultUnitOfMeasurementValidator.Errors.Count > 0)
            {
                createUnitOfMeasurementResponse.Success = false;
                createUnitOfMeasurementResponse.ValidationErrors = new List<string>();

                foreach (var errors in resultUnitOfMeasurementValidator.Errors)
                {
                    createUnitOfMeasurementResponse.ValidationErrors.Add(errors.ErrorMessage);
                }

            }

            if (createUnitOfMeasurementResponse.Success)
            {
                var gamme = new UnitOfMeasurement()
                {
                    Name = request.Name,
                };

                gamme = await _unitOfMeasurmentRepository.AddAsync(gamme);

                createUnitOfMeasurementResponse.UnitOfMeasurementDto = _mapper.Map<UnitOfMeasurementDto>(gamme);
            }

            return createUnitOfMeasurementResponse;
        }
    }
}
