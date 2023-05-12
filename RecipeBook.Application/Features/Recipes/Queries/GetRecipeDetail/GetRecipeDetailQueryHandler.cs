using AutoMapper;
using MediatR;
using RecipeBook.Application.Contracts.Persistence;
using RecipeBook.Application.Features.Recipes.Queries.CommonVM;
using RecipeBook.Application.Features.Recipes.Queries.GetRecipeDetail;
using RecipeBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeBook.Application.Features.Recipes.Queries.GetRecipeDetail
{
    public class GetRecipeDetailQueryHandler : IRequestHandler<GetRecipeDetailQuery, RecipeVM>
    {
        public readonly IRecipeRepository _recipeRepository;
        public readonly IMapper _mapper;

        public GetRecipeDetailQueryHandler(IRecipeRepository recipeRepository, IMapper mapper)
        {
            _recipeRepository = recipeRepository;
            _mapper = mapper;
        }

        public async Task<RecipeVM> Handle(GetRecipeDetailQuery request, CancellationToken cancellationToken)
        {
            var result = await _recipeRepository.GetByIdAsync(request.Id);  
            return _mapper.Map<RecipeVM>(result);
        }
    }
}
