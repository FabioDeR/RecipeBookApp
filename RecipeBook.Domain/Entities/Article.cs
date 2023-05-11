using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using RecipeBook.Domain.Common;

namespace RecipeBook.Domain.Entities
{
    public class Article : AuditableEntity
    {

        public float Quantity { get; set; }

        public Guid ProductId { get; set; }
        public virtual Product Product { get; set; } = default!;

        public Guid CultureId { get; set; }
        public virtual Culture Culture { get; set; } = default!;

        public Guid? CategoryId { get; set; }
        public virtual Category Category { get; set; } = default!;

        public Guid GammeId { get; set; }
        public virtual Gamme Gamme { get; set; } = default!;

        public Guid SupplierId { get; set; }
        public virtual Supplier Supplier { get; set; } = default!;

        public Guid? CutId { get; set; }
        public virtual Cut Cut { get; set; } = default!;

        public Guid? VarietyId { get; set; }
        public virtual Variety Variety { get; set; } = default!;
        public DateTime DLU { get; set; }
        public DateTime DLC { get; set; }
    }
}
