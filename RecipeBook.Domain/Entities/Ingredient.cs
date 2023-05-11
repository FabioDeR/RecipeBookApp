using RecipeBook.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeBook.Domain.Entities
{
    public class Ingredient : AuditableEntity
    { 
        public float Quantity { get; set; }     
        public Guid RecipeId { get; set; }
        public virtual Recipe Recipe { get; set; } = default!;
        public Guid ProductId { get; set; }
        public virtual Product Product { get; set; } = default!;
        public Guid? VarietyId { get; set; }
        public virtual Variety Variety { get; set; } = default!;
        public Guid UnitId { get; set; }
        public virtual UnitOfMeasurement Unit { get; set; } = default!;
    }
}
