using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeBook.Application.Features.Varieties.Commands.CreateVariety
{
    public class CreateVarietyCommandValidator : AbstractValidator<CreateVarietyCommand>
    {
        public CreateVarietyCommandValidator()
        {
            RuleFor(p => p.Name)
                   .NotEmpty().WithMessage("{PropertyName} is required")
                   .NotNull()
                   .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters ");

            RuleFor(p => p.ProductId)
                   .NotEmpty()
                   .WithMessage("Please select a product");
        }
    }
}
