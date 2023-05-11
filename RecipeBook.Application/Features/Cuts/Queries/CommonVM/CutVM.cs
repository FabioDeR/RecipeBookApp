using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeBook.Application.Features.Cuts.Queries.CommonVM
{
    public class CutVM
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
    }
}
