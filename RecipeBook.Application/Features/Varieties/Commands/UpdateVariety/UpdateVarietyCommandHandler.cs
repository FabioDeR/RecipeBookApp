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

namespace RecipeBook.Application.Features.Varieties.Commands.UpdateVariety
{
    public class UpdateVarietyCommandHandler : IRequestHandler<UpdateVarietyCommand>
    {
        public readonly IAsyncRepository<Variety> _varietyRepository;
        public readonly IMapper _mapper;

        public UpdateVarietyCommandHandler(IAsyncRepository<Variety> varietyRepository, IMapper mapper)
        {
            _varietyRepository = varietyRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateVarietyCommand request, CancellationToken cancellationToken)
        {
            var varietyUpdated = await _varietyRepository.GetByIdAsync(request.Id);
            if (varietyUpdated == null)
            {
                throw new NotFoundException(nameof(Variety), request.Id);
            }
            _mapper.Map(request, varietyUpdated);

            await _varietyRepository.UpdateAsync(varietyUpdated);

            return Unit.Value;
        }
    }
}
