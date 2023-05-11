using AutoMapper;
using MediatR;
using RecipeBook.Application.Contracts.Persistence;
using RecipeBook.Application.Features.Cuts.Queries.CommonVM;
using RecipeBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeBook.Application.Features.Cuts.Queries.CutList
{
    public class GetCutListQueryHandler : IRequestHandler<GetCutListQuery, List<CutVM>>
    {
        public readonly IAsyncRepository<Cut> _cutRepository;
        public readonly IMapper _mapper;

        public GetCutListQueryHandler(IAsyncRepository<Cut> cutRepository, IMapper mapper)
        {
            _cutRepository = cutRepository;
            _mapper = mapper;
        }
        public async Task<List<CutVM>> Handle(GetCutListQuery request, CancellationToken cancellationToken)
        {
            var allCut = await _cutRepository.ListAllAsync();

            return _mapper.Map<List<CutVM>>(allCut);
        }
    }
}
