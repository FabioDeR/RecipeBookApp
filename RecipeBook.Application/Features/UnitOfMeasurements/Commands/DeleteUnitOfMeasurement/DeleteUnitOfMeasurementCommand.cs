using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeBook.Application.Features.UnitOfMeasurements.Commands.DeleteUnitOfMeasurement
{
    public class DeleteUnitOfMeasurementCommand : IRequest
    {
        public Guid Id { get; set; }
    }
}
