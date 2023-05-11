using RecipeBook.Domain.Common;
using System.ComponentModel.DataAnnotations;

namespace RecipeBook.Domain.Entities
{
    public class StatementRecipe : AuditableEntity
    {       
        public string Name { get; set; } = string.Empty;
        public ICollection<Shift>? Shifts { get; set; }
    }
}