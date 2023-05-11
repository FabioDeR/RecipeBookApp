using MediatR;
using RecipeBook.Application.Features.Cuts.Queries.CommonVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeBook.Application.Features.Cuts.Queries.CutDetail
{
    public class GetCutDetailCommand : IRequest<CutVM>
    {
        public Guid Id { get; set; }
    }
}
