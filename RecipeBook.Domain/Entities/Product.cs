using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using RecipeBook.Domain.Common;

namespace RecipeBook.Domain.Entities
{
    public class Product : AuditableEntity
    {
        public string Name { get; set; } = string.Empty;   
        public Guid UnitId { get; set; }
        public virtual UnitOfMeasurement Unit { get; set; } = default!;    

        public ICollection<Variety>? Varieties { get; set; }

        public ICollection<Article>? Articles { get; set; }

        public ICollection<Ingredient>? Ingredients { get; set; }
    }
}