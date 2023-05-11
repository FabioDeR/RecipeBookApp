using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeBook.Application.Features.Ingredients.Command.UpdateIngredient
{
    public class UpdateIngredientCommand : IRequest
    {
        public Guid Id { get; set; }
        public float Quantity { get; set; }
        public Guid RecipeBookId { get; set; }
        public Guid ProductId { get; set; }
        public Guid? VarietyId { get; set; }
        public Guid UnitId { get; set; }
    }
}
