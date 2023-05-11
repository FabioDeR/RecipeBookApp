using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeBook.Application.Features.Gammes.Queries.CommonVM
{
    public class GammeVM
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
    }
}
