using AutoMapper;
using MediatR;
using RecipeBook.Application.Contracts.Persistence;
using RecipeBook.Application.Features.Gammes.Queries.CommonVM;
using RecipeBook.Application.Features.Gammes.Queries.GammeDetail;
using RecipeBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeBook.Application.Features.Gammes.Queries.GammeList
{
    public class GetGammeListHandlerQuery : IRequestHandler<GetGammeListQuery, List<GammeVM>>
    {
        public readonly IAsyncRepository<Gamme> _gammeRepository;
        public readonly IMapper _mapper;

        public GetGammeListHandlerQuery(IAsyncRepository<Gamme> gammeRepository, IMapper mapper)
        {
            _gammeRepository = gammeRepository;
            _mapper = mapper;
        }

        public async Task<List<GammeVM>> Handle(GetGammeListQuery request, CancellationToken cancellationToken)
        {
            var allGamme = await _gammeRepository.ListAllAsync();

            return _mapper.Map<List<GammeVM>>(allGamme);
        }
    }
}
