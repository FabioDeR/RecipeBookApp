using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeBook.Application.Features.Ingredients.Command.DeleteIngredient
{
    public class DeleteIngredientCommand : IRequest
    {
        public Guid Id { get; set; }
    }
}
