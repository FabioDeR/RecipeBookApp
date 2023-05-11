using RecipeBook.Domain.Common;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace RecipeBook.Domain.Entities
{
    public class Shift : AuditableEntity
    {    
        public DateTime Date { get; set; }       
        public float Quantity { get; set; }     
        public Guid RecipeBookId { get; set; }
        public virtual Recipe Recipe { get; set; } = default!;
        public Guid UnitId { get; set; }
        public virtual UnitOfMeasurement Unit { get; set; } = default!;        
        public Guid StatementRecipeId { get; set; }
        public virtual StatementRecipe StatementRecipe { get; set; } = default!;
    }
}