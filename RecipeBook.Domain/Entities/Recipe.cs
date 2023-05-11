using RecipeBook.Domain.Common;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace RecipeBook.Domain.Entities
{
    public class Recipe : AuditableEntity
    {   
        public string Name { get; set; } = string.Empty;    
        public float Quantity { get; set; }
        public string Comment { get; set; } = string.Empty;
        public Guid CultureId { get; set; }
        public virtual Culture Culture { get; set; } = default!;
        public Guid? ProductId { get; set; }
        public virtual Product Product { get; set; } = default!;
        public Guid UnitId { get; set; }
        public virtual UnitOfMeasurement Unit { get; set; } = default!;
        public Guid? CutId { get; set; }
        public virtual Cut Cut { get; set; } = default!;
        public DateTime? InternalValidation { get; set; }
        public DateTime? ExternalValidation { get; set; }
        public ICollection<Ingredient>? Ingredients { get; set; }
        public ICollection<Shift>? Shifts { get; set; }
        
    }
}