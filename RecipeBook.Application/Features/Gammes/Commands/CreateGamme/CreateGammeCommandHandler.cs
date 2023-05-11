using AutoMapper;
using MediatR;
using RecipeBook.Application.Contracts.Persistence;
using RecipeBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeBook.Application.Features.Gammes.Commands.CreateGamme
{
    public class CreateGammeCommandHandler : IRequestHandler<CreateGammeCommand, CreateGammeCommandReponse>
    {
        public readonly IAsyncRepository<Gamme> _gammeRepository;
        public readonly IMapper _mapper;

        public CreateGammeCommandHandler(IAsyncRepository<Gamme> gammeRepository, IMapper mapper)
        {
            _gammeRepository = gammeRepository;
            _mapper = mapper;
        }

        public async Task<CreateGammeCommandReponse> Handle(CreateGammeCommand request, CancellationToken cancellationToken)
        {
            var createGammeResponse = new CreateGammeCommandReponse();
            var createGammeValidator = new CreateGammeCommandValidator();

            var resultGammmeValidator = await createGammeValidator.ValidateAsync(request);

            if(resultGammmeValidator.Errors.Count > 0)
            {
                createGammeResponse.Success = false;
                createGammeResponse.ValidationErrors = new List<string>();

                foreach (var errors in resultGammmeValidator.Errors)
                {
                    createGammeResponse.ValidationErrors.Add(errors.ErrorMessage);
                }

            }

            if(createGammeResponse.Success)
            {
                var gamme = new Gamme()
                {
                    Name = request.Name,
                };

                gamme = await _gammeRepository.AddAsync(gamme);

                createGammeResponse.GammeDto = _mapper.Map<GammeDto>(gamme);
            }

            return createGammeResponse; 
        }
    }
}
