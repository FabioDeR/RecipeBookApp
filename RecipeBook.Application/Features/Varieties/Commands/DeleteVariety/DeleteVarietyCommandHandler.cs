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

namespace RecipeBook.Application.Features.Varieties.Commands.DeleteVariety
{
    public class DeleteVarietyCommandHandler : IRequestHandler<DeleteVarietyCommand>
    {
        public readonly IAsyncRepository<Variety> _varietyRepository;
        public readonly IMapper _mapper;

        public DeleteVarietyCommandHandler(IAsyncRepository<Variety> varietyRepository, IMapper mapper)
        {
            _varietyRepository = varietyRepository;
            _mapper = mapper;
        }
        public async Task<Unit> Handle(DeleteVarietyCommand request, CancellationToken cancellationToken)
        {
            var deletedVariety = await _varietyRepository.GetByIdAsync(request.Id);
            if (deletedVariety == null)
            {
                throw new NotFoundException(nameof(Variety), request.Id);
            }

            await _varietyRepository.DeleteAsync(deletedVariety);

            return Unit.Value;
        }
    }
}
