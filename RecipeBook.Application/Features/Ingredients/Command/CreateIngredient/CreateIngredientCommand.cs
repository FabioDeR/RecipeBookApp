using MediatR;
using RecipeBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeBook.Application.Features.Ingredients.Command.CreateIngredient
{
    public class CreateIngredientCommand : IRequest<CreateIngredientCommandResponse>
    {
        public float Quantity { get; set; }
        public Guid RecipeBookId { get; set; }      
        public Guid ProductId { get; set; }       
        public Guid? VarietyId { get; set; }       
        public Guid UnitId { get; set; }        
    }
}
