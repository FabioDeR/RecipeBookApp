using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeBook.Application.Features.Cultures.Commands.CreateCulture
{
    public class CreateCultureValidator : AbstractValidator<CreateCultureCommand>
    {
        public CreateCultureValidator()
        {
            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 10 characters ");

        }
    }
}
