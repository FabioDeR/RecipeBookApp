using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeBook.Application.Features.Recipes.Queries.CommonVM
{
    public class RecipeVM
    {
        public string Name { get; set; } = string.Empty;

        public string ProductName { get; set; } = string.Empty;
        
        public string UnitName { get; set; } = string.Empty;

        public float Quantity { get; set; }


    }
}
