using MediatR;
using RecipeBook.Application.Features.Recipes.Queries.GetRecipeDetail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeBook.Application.Features.Recipes.Queries.GetRecipeDetail
{
    public class GetRecipeDetailQueryHandler : IRequestHandler<GetRecipeDetailQuery>
    {
        public Task<Unit> Handle(GetRecipeDetailQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
