using MediatR;
using RecipeBook.Application.Features.Recipes.Queries.CommonVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeBook.Application.Features.Recipes.Queries.GetListRecipe
{
    public class GetListRecipeQuery : IRequest<List<RecipeVM>>
    {

    }
}
