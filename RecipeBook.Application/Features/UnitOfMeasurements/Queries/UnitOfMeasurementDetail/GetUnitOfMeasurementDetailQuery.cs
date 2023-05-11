using MediatR;
using RecipeBook.Application.Features.UnitOfMeasurements.Queries.CommonVM;
using RecipeBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeBook.Application.Features.UnitOfMeasurements.Queries.UnitOfMeasurementDetail
{
    public class GetUnitOfMeasurementDetailQuery : IRequest<UnitOfMeasurementDetailVM>
    {
        public Guid Id { get; set; }
    }
}
