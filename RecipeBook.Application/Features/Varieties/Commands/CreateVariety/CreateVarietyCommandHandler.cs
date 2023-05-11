using AutoMapper;
using MediatR;
using RecipeBook.Application.Contracts.Persistence;
using RecipeBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeBook.Application.Features.Varieties.Commands.CreateVariety
{
    public class CreateVarietyCommandHandler : IRequestHandler<CreateVarietyCommand, CreateVarietyCommandResponse>
    {
        public readonly IAsyncRepository<Variety> _varietyRepository;
        public readonly IMapper _mapper;

        public CreateVarietyCommandHandler(IAsyncRepository<Variety> varietyRepository, IMapper mapper)
        {
            _varietyRepository = varietyRepository;
            _mapper = mapper;
        }

        public async Task<CreateVarietyCommandResponse> Handle(CreateVarietyCommand request, CancellationToken cancellationToken)
        {
            
            var createVarietyResponse = new CreateVarietyCommandResponse();
            var createValidatorRepsonse = new CreateVarietyCommandValidator();

            var validatorResult = await createValidatorRepsonse.ValidateAsync(request);

            if(validatorResult.Errors.Count > 0)
            {
                createVarietyResponse.Success = false;
                createVarietyResponse.ValidationErrors = new List<string>();

                foreach (var errors in validatorResult.Errors)
                {
                    createVarietyResponse.ValidationErrors.Add(errors.ErrorMessage);
                }

            }

            if (validatorResult.IsValid)
            {
                createVarietyResponse.Success = true;
                var variety = new Variety()
                {
                    Name= request.Name,
                    ProductId= request.ProductId,
                };
                variety = await _varietyRepository.AddAsync(variety);
                createVarietyResponse.VarietyDto = _mapper.Map<VarietyDto>(variety);
            }

            return createVarietyResponse;

        }
    }
}
