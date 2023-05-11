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

namespace RecipeBook.Application.Features.Cultures.Commands.UpdateCulture
{
    public class UpdateCultureCommandHandler : IRequestHandler<UpdateCultureCommand>
    {
        public readonly IAsyncRepository<Culture> _cultureRepository;
        public readonly IMapper _mapper;
        public UpdateCultureCommandHandler(IAsyncRepository<Culture> cultureRepository, IMapper mapper)
        {
            _cultureRepository = cultureRepository;
            _mapper = mapper;
        }

        public async Task<MediatR.Unit> Handle(UpdateCultureCommand request, CancellationToken cancellationToken)
        {
            var cultureUpdated = await _cultureRepository.GetByIdAsync(request.Id);
            if (cultureUpdated == null)
            {
                throw new NotFoundException(nameof(Culture), request.Id);
            }
            _mapper.Map(request, cultureUpdated);

            await _cultureRepository.UpdateAsync(cultureUpdated);

            return MediatR.Unit.Value;
            
        }
    }
}
