using AutoMapper;
using MediatR;
using RecipeBook.Application.Contracts.Persistence;
using RecipeBook.Application.Exceptions;
using RecipeBook.Application.Features.Cuts.Queries.CommonVM;
using RecipeBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeBook.Application.Features.Cuts.Queries.CutDetail
{
    public class GetCutDetailQueryHandler : IRequestHandler<GetCutDetailCommand, CutVM>
    {
        public readonly IAsyncRepository<Cut> _cutRepository;
        public readonly IMapper _mapper;

        public GetCutDetailQueryHandler(IAsyncRepository<Cut> cutRepository, IMapper mapper)
        {
            _cutRepository = cutRepository;
            _mapper = mapper;
        }
        public async Task<CutVM> Handle(GetCutDetailCommand request, CancellationToken cancellationToken)
        {
            var cutDetail = await _cutRepository.GetByIdAsync(request.Id);
            if (cutDetail == null)
            {
                throw new NotFoundException(nameof(Cut), request.Id);
            }

            return _mapper.Map<CutVM>(cutDetail);
        }
    }
}
