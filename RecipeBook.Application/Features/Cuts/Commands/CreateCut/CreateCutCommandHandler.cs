using AutoMapper;
using MediatR;
using RecipeBook.Application.Contracts.Persistence;
using RecipeBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeBook.Application.Features.Cuts.Commands.CreateCut
{

    public class CreateCutCommandHandler : IRequestHandler<CreateCutCommand, CreateCutCommandResponse>
    {
        private readonly IAsyncRepository<Cut> _cutRepository;
        private readonly IMapper _mapper;

        public CreateCutCommandHandler(IMapper mapper, IAsyncRepository<Cut> cutRepository)
        {
            _mapper = mapper;
            _cutRepository = cutRepository;
        }
        public async Task<CreateCutCommandResponse> Handle(CreateCutCommand request, CancellationToken cancellationToken)
        {
            var cutResponse = new CreateCutCommandResponse();
            var cutValidator = new CreateCutValidator();

            var resultValidator = await cutValidator.ValidateAsync(request);

            if (resultValidator.Errors.Count != 0)
            {
                cutResponse.Success = false;
                cutResponse.ValidationErrors = new List<string>();

                foreach (var error in resultValidator.Errors)
                {
                    cutResponse.ValidationErrors.Add(error.ErrorMessage);
                }
            }

            if (cutResponse.Success)
            {
                var cut = new Cut()
                {
                    Name = request.Name,
                };
                cut = await _cutRepository.AddAsync(cut);
                cutResponse.CutDto = _mapper.Map<CutDto>(cut);
            }

            return cutResponse;
        }
    }
}
