using AutoMapper;
using MediatR;
using RecipeBook.Application.Contracts.Persistence;
using RecipeBook.Application.Exceptions;
using RecipeBook.Application.Features.Cultures.Queries.CommonVM;
using RecipeBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeBook.Application.Features.Cultures.Queries.CultureDetail
{
    public class GetCultureDetailQueryHandler : IRequestHandler<GetCultureDetailQuery, CultureVM>
    {
        public readonly IAsyncRepository<Culture> _cultureRepository;
        public readonly IMapper _mapper;

        public GetCultureDetailQueryHandler(IAsyncRepository<Culture> cultureRepository, IMapper mapper)
        {
            _cultureRepository = cultureRepository;
            _mapper = mapper;
        }

        public async Task<CultureVM> Handle(GetCultureDetailQuery request, CancellationToken cancellationToken)
        {
            var cultureDetail = await _cultureRepository.GetByIdAsync(request.Id);

            if (cultureDetail == null)
            {
                throw new NotFoundException(nameof(Culture),request.Id);
            }

            var cultureVm = _mapper.Map<CultureVM>(cultureDetail);

            return cultureVm;
        }
    }
}
