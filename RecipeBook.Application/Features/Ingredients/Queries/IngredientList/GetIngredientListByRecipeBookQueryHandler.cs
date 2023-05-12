using MediatR;
using RecipeBook.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeBook.Application.Features.Ingredients.Queries.IngredientList
{
    public class GetIngredientListByRecipeBookQueryHandler : IRequestHandler<GetIngredientListByRecipeBookQuery, List<IngredientListByRecipeBookVM>>
    {
        public readonly IIngredientRepository _ingredientRepository;

        public GetIngredientListByRecipeBookQueryHandler(IIngredientRepository ingredientRepository)
        {
            _ingredientRepository = ingredientRepository;
        }

        public async Task<List<IngredientListByRecipeBookVM>> Handle(GetIngredientListByRecipeBookQuery request, CancellationToken cancellationToken)
        {
            return await _ingredientRepository.GetIngredientListByRecipeBook(request.RecipeId);
        }
    }
}
