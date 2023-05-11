using MediatR;
using RecipeBook.Application.Features.UnitOfMeasurements.Queries.CommonVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeBook.Application.Features.UnitOfMeasurements.Queries.UnitOfMeasurementList
{
    public class GetUnitOfMeasurementListQuery : IRequest<List<UnitOfMeasurementDetailVM>>
    {
    }
}
