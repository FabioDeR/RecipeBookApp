using MediatR;
using RecipeBook.Application.Features.Ingredients.Queries.IngredientDetail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeBook.Application.Features.Ingredients.Queries.IngredientList
{
    public class GetIngredientListByRecipeBookQuery : IRequest<List<IngredientListByRecipeBookVM>>
    {
        public Guid RecipeId { get; set; }
    }
}
