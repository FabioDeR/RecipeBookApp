using MediatR;
using RecipeBook.Application.Features.Gammes.Queries.CommonVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeBook.Application.Features.Gammes.Queries.GammeList
{
    public class GetGammeListQuery : IRequest<List<GammeVM>>
    {
    }
}
