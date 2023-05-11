using MediatR;
using RecipeBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeBook.Application.Features.Recipes.Commands.CreateRecipe
{
    public class CreateRecipeCommand : IRequest<CreateRecipeCommandResponse>
    {

        public string Name { get; set; } = string.Empty;
        public float Quantity { get; set; }
        public string Comment { get; set; } = string.Empty;
        public Guid CultureId { get; set; }
        public Guid? ProductId { get; set; }
        public Guid UnitId { get; set; }
        public Guid? CutId { get; set; }
        public DateTime? InternalValidation { get; set; }
        public DateTime? ExternalValidation { get; set; }


    }
}
