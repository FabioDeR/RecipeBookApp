using RecipeBook.Domain.Common;
using System.ComponentModel.DataAnnotations;

namespace RecipeBook.Domain.Entities
{
    public class Supplier : AuditableEntity
    {    
        public string Name { get; set; } = string.Empty;
        public ICollection<Article>? Articles { get; set; }
    }
}