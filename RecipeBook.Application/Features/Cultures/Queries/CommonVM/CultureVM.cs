using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeBook.Application.Features.Cultures.Queries.CommonVM
{
    public class CultureVM
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
    }
}
