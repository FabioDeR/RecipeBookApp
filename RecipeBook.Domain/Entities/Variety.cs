using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using RecipeBook.Domain.Common;

namespace RecipeBook.Domain.Entities
{
    public class Variety : AuditableEntity
    {
        public string Name { get; set; } = string.Empty;      
        public Guid ProductId { get; set; }
        public virtual Product Product { get; set; } = default!;
        public ICollection<Ingredient>? Ingredients { get; set; }
        public ICollection<Article>? Articles { get; set; }
    }
}