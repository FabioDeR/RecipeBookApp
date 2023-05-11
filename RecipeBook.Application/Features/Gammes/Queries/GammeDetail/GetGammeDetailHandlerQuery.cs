using AutoMapper;
using MediatR;
using RecipeBook.Application.Contracts.Persistence;
using RecipeBook.Application.Exceptions;
using RecipeBook.Application.Features.Gammes.Queries.CommonVM;
using RecipeBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeBook.Application.Features.Gammes.Queries.GammeDetail
{
    public class GetGammeDetailHandlerQuery : IRequestHandler<GetGammeDetailQuery, GammeVM>
    {
        public readonly IAsyncRepository<Gamme> _gammeRepository;
        public readonly IMapper _mapper;

        public GetGammeDetailHandlerQuery(IAsyncRepository<Gamme> gammeRepository, IMapper mapper)
        {
            _gammeRepository = gammeRepository;
            _mapper = mapper;
        }

        public async Task<GammeVM> Handle(GetGammeDetailQuery request, CancellationToken cancellationToken)
        {
            var gammeDetail = await _gammeRepository.GetByIdAsync(request.Id);

            if (gammeDetail == null)
            {
                throw new NotFoundException(nameof(Gamme), request.Id);
            }

            return _mapper.Map<GammeVM>(gammeDetail);
        }
    }
}
