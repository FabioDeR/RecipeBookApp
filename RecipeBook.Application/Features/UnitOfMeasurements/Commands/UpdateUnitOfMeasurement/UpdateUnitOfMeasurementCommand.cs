using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeBook.Application.Features.UnitOfMeasurements.Commands.UpdateUnitOfMeasurement
{
    public class UpdateUnitOfMeasurementCommand : IRequest
    {
        public Guid Id { get; set; }

        public string Name { get; set; } = string.Empty;
    }
}
