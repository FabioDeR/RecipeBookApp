using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeBook.Application.Features.Gammes.Commands.CreateGamme
{
    public class CreateGammeCommandValidator : AbstractValidator<CreateGammeCommand>
    {
        public CreateGammeCommandValidator()
        {
            RuleFor(p => p.Name)
                   .NotEmpty().WithMessage("{PropertyName} is required")
                   .NotNull()
                   .MaximumLength(50).WithMessage("{PropertyName} must not exceed 10 characters ");
        }
    }
}
