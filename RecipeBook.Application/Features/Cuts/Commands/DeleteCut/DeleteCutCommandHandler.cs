using MediatR;
using RecipeBook.Application.Contracts.Persistence;
using RecipeBook.Application.Exceptions;
using RecipeBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeBook.Application.Features.Cuts.Commands.DeleteCut
{
    public class DeleteCutCommandHandler : IRequestHandler<DeleteCutCommand>
    {
        public readonly IAsyncRepository<Cut> _cutRepository;

        public DeleteCutCommandHandler(IAsyncRepository<Cut> cutRepository)
        {
            _cutRepository = cutRepository;
        }

        public async Task<MediatR.Unit> Handle(DeleteCutCommand request, CancellationToken cancellationToken)
        {
            var cutdeleted = await _cutRepository.GetByIdAsync(request.Id);

            if (cutdeleted == null)
            {
                throw new NotFoundException(nameof(Culture), request.Id);
            }

            await _cutRepository.DeleteAsync(cutdeleted);

            return MediatR.Unit.Value;
        }
    }
}
