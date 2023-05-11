using MediatR;
using RecipeBook.Application.Features.Categories.Queries.CommonVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeBook.Application.Features.Categories.Queries.GetCategoryList
{
    public class GetListCategoryQuery : IRequest<List<CategoryVM>>
    {
    }
}
