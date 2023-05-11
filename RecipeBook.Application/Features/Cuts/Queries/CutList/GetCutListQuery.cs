using MediatR;
using RecipeBook.Application.Features.Cuts.Queries.CommonVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeBook.Application.Features.Cuts.Queries.CutList
{
    public class GetCutListQuery : IRequest<List<CutVM>>
    {
    }
}
