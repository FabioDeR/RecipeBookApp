using MediatR;
using RecipeBook.Application.Contracts.Persistence;
using RecipeBook.Application.Features.Recipes.Queries.CommonVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeBook.Application.Features.Recipes.Queries.GetListRecipe
{
    public class GetListRecipeQueryHandler : IRequestHandler<GetListRecipeQuery, List<RecipeVM>>
    {
        
        private readonly IRecipeRepository _recipeRepository;

        public GetListRecipeQueryHandler(IRecipeRepository recipeRepository)
        {
            _recipeRepository = recipeRepository;
        }

        public async Task<List<RecipeVM>> Handle(GetListRecipeQuery request, CancellationToken cancellationToken)
        {
            List<RecipeVM> recipeBookList = await _recipeRepository.GetListRecipeBook();
            return recipeBookList;
        }
    }
}
