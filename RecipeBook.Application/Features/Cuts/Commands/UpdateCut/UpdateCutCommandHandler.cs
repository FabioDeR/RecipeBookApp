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

namespace RecipeBook.Application.Features.Cuts.Commands.UpdateCut
{
    public class UpdateCutCommandHandler : IRequestHandler<UpdateCutCommand>
    {
        public readonly IAsyncRepository<Cut> _cutRepository;
        public readonly IMapper _mapper;

        public UpdateCutCommandHandler(IAsyncRepository<Cut> cutRepository, IMapper mapper)
        {
            _cutRepository = cutRepository;
            _mapper = mapper;
        }

        public async Task<MediatR.Unit> Handle(UpdateCutCommand request, CancellationToken cancellationToken)
        {
            var cutUpdated = await _cutRepository.GetByIdAsync(request.Id);

            if (cutUpdated == null)
            {
                throw new NotFoundException(nameof(Cut), request.Id);
            }

            _mapper.Map(request, cutUpdated);

            await _cutRepository.UpdateAsync(cutUpdated);

            return MediatR.Unit.Value;
        }
    }
}
