using RecipeBook.Domain.Common;
using System.ComponentModel.DataAnnotations;

namespace RecipeBook.Domain.Entities
{
    public class UnitOfMeasurement : AuditableEntity
    { 
        public string Name { get; set; } = string.Empty;           
        public ICollection<Variety>? Varieties { get; set; }
        public ICollection<Product>? Products { get; set; }
        public ICollection<Ingredient>? Ingredients { get; set; }
        public ICollection<Shift>? Shifts { get; set; }
        public ICollection<Recipe>? Recipes { get; set; }
    }
}