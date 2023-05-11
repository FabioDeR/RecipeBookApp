using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeBook.Application.Features.Recipes.Queries.GetRecipeDetail
{
    public class GetRecipeDetailQuery : IRequest
    {
        public Guid Id { get; set; }
    }
}
