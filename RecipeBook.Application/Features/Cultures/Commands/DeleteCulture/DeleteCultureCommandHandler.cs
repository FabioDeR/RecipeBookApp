using MediatR;
using RecipeBook.Application.Contracts.Persistence;
using RecipeBook.Application.Exceptions;
using RecipeBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeBook.Application.Features.Cultures.Commands.DeleteCulture
{
    public class DeleteCultureCommandHandler : IRequestHandler<DeleteCultureCommand>
    {
        public readonly IAsyncRepository<Culture> _cultureRepository;

        public DeleteCultureCommandHandler(IAsyncRepository<Culture> cultureRepository)
        {
            _cultureRepository = cultureRepository;
        }

        public async Task<MediatR.Unit> Handle(DeleteCultureCommand request, CancellationToken cancellationToken)
        {
            var cultureDeleted = await _cultureRepository.GetByIdAsync(request.Id);

            if (cultureDeleted == null)
            {
                throw new NotFoundException(nameof(Culture), request.Id);
            }

            await _cultureRepository.DeleteAsync(cultureDeleted);

            return MediatR.Unit.Value;
        }
    }
}
