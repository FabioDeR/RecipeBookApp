using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeBook.Application.Features.Ingredients.Queries.IngredientDetail
{
    public class GetIngredientDetailQuery : IRequest<IngredientVM>
    {
        public Guid Id { get; set; }
    }
}
