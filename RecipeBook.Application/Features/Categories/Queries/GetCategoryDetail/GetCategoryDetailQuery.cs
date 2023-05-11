using MediatR;
using RecipeBook.Application.Features.Categories.Queries.CommonVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeBook.Application.Features.Categories.Queries.GetCategoryDetail
{
    public class GetCategoryDetailQuery : IRequest<CategoryVM>
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
    }
}
