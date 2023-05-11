using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeBook.Application.Features.UnitOfMeasurements.Commands.CreateUnitOfMeasurement
{
    public class CreateUnitOfMeasurementValidator : AbstractValidator<CreateUnitOfMeasurementCommand>
    {
        public CreateUnitOfMeasurementValidator() 
        {

            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters ");

        }
    }
}
