using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeBook.Application.Features.UnitOfMeasurements.Commands.CreateUnitOfMeasurement
{
    public class CreateUnitOfMeasurementCommand : IRequest<CreateUnitOfMeasurementResponse>
    {
        public string Name { get; set; } = string.Empty;
    }
}
