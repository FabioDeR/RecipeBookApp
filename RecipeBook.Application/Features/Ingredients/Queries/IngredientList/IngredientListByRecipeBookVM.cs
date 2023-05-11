using RecipeBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeBook.Application.Features.Ingredients.Queries.IngredientList
{
    public class IngredientListByRecipeBookVM
    {
        public float Quantity { get; set; }       
        public string ProductName { get; set; } = string.Empty;
        public string VarietyName { get; set; } = string.Empty;     
        public string UnitName { get; set; } = string.Empty;
        
    }
}
