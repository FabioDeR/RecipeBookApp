using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeBook.Application.Features.Ingredients.Command.CreateIngredient
{
    public class CreateIngredientCommandValidator : AbstractValidator<CreateIngredientCommand>
    {
        public CreateIngredientCommandValidator()
        {
            RuleFor(e => e.Quantity)
                .NotNull()
                .WithMessage("{PropertyName} is required")
                .GreaterThan(0)
                .WithMessage("{PropertyName} must be greater than 0");

            RuleFor(e => e.RecipeBookId)
               .NotNull()
               .NotEmpty()
               .WithMessage("{PropertyName} is required");

            RuleFor(e => e.ProductId)
               .NotNull()
               .NotEmpty()
               .WithMessage("{PropertyName} is required");

            RuleFor(e => e.VarietyId)
               .NotNull()
               .NotEmpty()
               .WithMessage("{PropertyName} is required");

            RuleFor(e => e.UnitId)
              .NotNull()
              .NotEmpty()
              .WithMessage("{PropertyName} is required");




        }
    
    }
}
