using AutoMapper;
using MediatR;
using RecipeBook.Application.Contracts.Persistence;
using RecipeBook.Application.Features.Cultures.Queries.CommonVM;
using RecipeBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeBook.Application.Features.Cultures.Queries.CultureList
{
    public class GetCultureListQueryHandler : IRequestHandler<GetCultureListQuery, List<CultureVM>>
    {
        public readonly IAsyncRepository<Culture> _cultureRepository;
        public readonly IMapper _mapper;

        public GetCultureListQueryHandler(IAsyncRepository<Culture> cultureRepository, IMapper mapper)
        {
            _cultureRepository = cultureRepository;
            _mapper = mapper;
        }

        public async Task<List<CultureVM>> Handle(GetCultureListQuery request, CancellationToken cancellationToken)
        {
            var allCulture = (await _cultureRepository.ListAllAsync()).OrderBy(p => p.Name);

            return _mapper.Map<List<CultureVM>>(allCulture);
        }
    }
}
