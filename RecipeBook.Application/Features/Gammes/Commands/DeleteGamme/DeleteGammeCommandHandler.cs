using MediatR;
using RecipeBook.Application.Contracts.Persistence;
using RecipeBook.Application.Exceptions;
using RecipeBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeBook.Application.Features.Gammes.Commands.DeleteGamme
{
    public class DeleteGammeCommandHandler : IRequestHandler<DeleteGammeCommand>
    {
        private readonly IAsyncRepository<Gamme> _gammeRepository;

        public DeleteGammeCommandHandler(IAsyncRepository<Gamme> gammeRepository)
        {
            _gammeRepository = gammeRepository;
        }

        public async Task<MediatR.Unit> Handle(DeleteGammeCommand request, CancellationToken cancellationToken)
        {
            var gammedeleted = await _gammeRepository.GetByIdAsync(request.Id);

            if (gammedeleted == null)
            {
                throw new NotFoundException(nameof(Gamme), request.Id);
            }

            await _gammeRepository.DeleteAsync(gammedeleted);

            return MediatR.Unit.Value;
        }
    }
}
