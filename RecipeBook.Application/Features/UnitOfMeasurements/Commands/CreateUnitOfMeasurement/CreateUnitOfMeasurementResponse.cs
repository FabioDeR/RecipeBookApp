using RecipeBook.Application.Responses;
using RecipeBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeBook.Application.Features.UnitOfMeasurements.Commands.CreateUnitOfMeasurement
{
    public class CreateUnitOfMeasurementResponse : BaseResponse
    {

        public UnitOfMeasurementDto UnitOfMeasurementDto { get; set; } = default!;
    }
}
