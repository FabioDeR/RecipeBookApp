using AutoMapper;
using MediatR;
using RecipeBook.Application.Contracts.Persistence;
using RecipeBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeBook.Application.Features.Cultures.Commands.CreateCulture
{
    public class CreateCultureCommandHandler : IRequestHandler<CreateCultureCommand, CreateCultureCommandResponse>
    {
        private readonly IAsyncRepository<Culture> _cultureRepository;
        private readonly IMapper _mapper;

        public CreateCultureCommandHandler(IMapper mapper, IAsyncRepository<Culture> cultureRepository)
        {
            _mapper = mapper;
            _cultureRepository = cultureRepository;
        }


        public async Task<CreateCultureCommandResponse> Handle(CreateCultureCommand request, CancellationToken cancellationToken)
        {
            var cultureResponse = new CreateCultureCommandResponse();
            var createCultureValidator = new CreateCultureValidator();

            var validatorResult = await createCultureValidator.ValidateAsync(request);

            if (validatorResult.Errors.Count != 0)
            {
                cultureResponse.Success = false;
                cultureResponse.ValidationErrors = new List<string>();
                foreach (var item in validatorResult.Errors)
                {
                    cultureResponse.ValidationErrors.Add(item.ErrorMessage);
                }
            }

            if(cultureResponse.Success)
            {
                var culture = new Culture()
                {
                    Name = request.Name,
                };
                culture = await _cultureRepository.AddAsync(culture);
                cultureResponse.CultureDto =  _mapper.Map<CultureDto>(culture);
            }

            return cultureResponse;
        }
    }
}
