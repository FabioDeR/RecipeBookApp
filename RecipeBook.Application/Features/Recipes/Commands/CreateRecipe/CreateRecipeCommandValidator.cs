using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeBook.Application.Features.Recipes.Commands.CreateRecipe
{
    public class CreateRecipeCommandValidator : AbstractValidator<CreateRecipeCommand>
    {
        public CreateRecipeCommandValidator()
        {

            RuleFor(e => e.Name)
                   .NotEmpty()
                   .WithMessage("{PropertyName} is required")
                   .NotNull()
                   .MaximumLength(50)
                   .WithMessage("{PropertyName} must not excees 50 characters");

            RuleFor(e => e.Comment)
                   .MaximumLength(150)
                   .WithMessage("{PropertyName} must not exceed 150 characters");

            RuleFor(e => e.CultureId)
                  .NotEmpty()
                  .WithMessage("{PropertyName} is required")
                  .NotNull();

            RuleFor(e => e.UnitId)
                 .NotEmpty()
                 .WithMessage("{PropertyName} is required")
                 .NotNull();


        }
    }
}
