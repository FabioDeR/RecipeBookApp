using RecipeBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeBook.Application.Features.Recipes.Queries.CommonVM
{
    public class RecipeVM
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Comment { get; set; } = string.Empty;
        public Guid? ProductId { get; set; }
        public string ProductName { get; set; } = string.Empty;
        public Guid? UnitId { get; set; }
        public string UnitName { get; set; } = string.Empty;
        public float Quantity { get; set; }
        public Guid CultureId { get; set; }
        public string CultureName { get; set; } = string.Empty;
    }
}
