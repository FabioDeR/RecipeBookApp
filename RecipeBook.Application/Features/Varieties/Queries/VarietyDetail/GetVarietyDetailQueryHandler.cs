using MediatR;
using RecipeBook.Application.Contracts.Persistence;
using RecipeBook.Application.Exceptions;
using RecipeBook.Application.Features.Varieties.Queries.CommonVM;
using RecipeBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeBook.Application.Features.Varieties.Queries.VarietyDetail
{
    public class GetVarietyDetailQueryHandler : IRequestHandler<GetVarietyDetailQuery, VarietyDetailVM>
    {
        public readonly IVarietyRepository _varietyRepository;

        public GetVarietyDetailQueryHandler(IVarietyRepository varietyRepository)
        {
            _varietyRepository = varietyRepository;
        }

        public async Task<VarietyDetailVM> Handle(GetVarietyDetailQuery request, CancellationToken cancellationToken)
        {
            VarietyDetailVM varietyDetail = await _varietyRepository.GetVarietyDetailWithProductInfo(request.Id);

            if (varietyDetail == null)
            {
                throw new NotFoundException(nameof(Variety), request.Id);
            }

            return varietyDetail;
        }
    }
}
