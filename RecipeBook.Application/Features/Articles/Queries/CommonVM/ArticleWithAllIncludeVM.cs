using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeBook.Application.Features.Articles.Queries.CommonVM
{
    public class ArticleWithAllIncludeVM
    {
        public Guid ArticleId { get; set; }
        public float Quantity { get; set; }
        public Guid ProductId { get; set; }
        public string ProductName { get; set; } = string.Empty;
        public Guid CultureId { get; set; }
        public string CultureName { get; set; } = string.Empty;
        public Guid? CategoryId { get; set; }
        public string CategoryName { get; set; } = string.Empty;
        public Guid GammeId { get; set; }
        public string GammeName { get; set; } = string.Empty;
        public Guid SupplierId { get; set; }
        public string SupplierName { get; set; } = string.Empty;
        public Guid? CutId { get; set; }
        public string CutName { get; set; } = string.Empty;
        public Guid? VarietyId { get; set; }
        public string VaietyName { get; set; } = string.Empty;
        public DateTime DLU { get; set; }
        public DateTime DLC { get; set; }
       
    }
}
