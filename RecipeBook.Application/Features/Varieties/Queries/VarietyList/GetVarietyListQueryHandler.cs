using MediatR;
using RecipeBook.Application.Contracts.Persistence;
using RecipeBook.Application.Features.Varieties.Queries.CommonVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeBook.Application.Features.Varieties.Queries.VarietyList
{
    public class GetVarietyListQueryHandler : IRequestHandler<GetVarietyListQuery, List<VarietyDetailVM>>
    {
        public readonly IVarietyRepository _varietyRepository;

        public GetVarietyListQueryHandler(IVarietyRepository varietyRepository)
        {
            _varietyRepository = varietyRepository;
        }


        public async Task<List<VarietyDetailVM>> Handle(GetVarietyListQuery request, CancellationToken cancellationToken)
        {
            List<VarietyDetailVM> varietyList = await _varietyRepository.GetVarietyListWithProductInfo();

            return varietyList;


        }
    }
}
