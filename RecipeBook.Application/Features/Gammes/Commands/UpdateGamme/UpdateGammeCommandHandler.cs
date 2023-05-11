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

namespace RecipeBook.Application.Features.Gammes.Commands.UpdateGamme
{
    public class UpdateGammeCommandHandler : IRequestHandler<UpdateGammeCommand>
    {
        private readonly IAsyncRepository<Gamme> _gammeRepository;
        private readonly IMapper _mapper;

        public UpdateGammeCommandHandler(IAsyncRepository<Gamme> gammeRepository, IMapper mapper)
        {
            _gammeRepository = gammeRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateGammeCommand request, CancellationToken cancellationToken)
        {
            var gammeUpdated = await _gammeRepository.GetByIdAsync(request.Id);

            if (gammeUpdated == null) {

                throw new NotFoundException(nameof(Gamme), request.Id);
            
            }
            _mapper.Map(request,gammeUpdated);

            await _gammeRepository.UpdateAsync(gammeUpdated);

            return Unit.Value;
        }
    }
}
