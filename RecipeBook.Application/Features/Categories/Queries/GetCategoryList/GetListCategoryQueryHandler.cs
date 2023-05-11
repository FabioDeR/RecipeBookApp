using AutoMapper;
using MediatR;
using RecipeBook.Application.Contracts.Persistence;
using RecipeBook.Application.Features.Categories.Queries.CommonVM;
using RecipeBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeBook.Application.Features.Categories.Queries.GetCategoryList
{
    public class GetListCategoryQueryHandler : IRequestHandler<GetListCategoryQuery, List<CategoryVM>>
    {
        public readonly ICategoryRepository _categoryRepository;
        public readonly IMapper _mapper;

        public GetListCategoryQueryHandler(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<List<CategoryVM>> Handle(GetListCategoryQuery request, CancellationToken cancellationToken)
        {
            var allCategory = await _categoryRepository.ListAllAsync();

            return _mapper.Map<List<CategoryVM>>(allCategory); ;
        }
    }
}
