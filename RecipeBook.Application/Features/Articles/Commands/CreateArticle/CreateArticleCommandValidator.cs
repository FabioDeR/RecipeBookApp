using FluentValidation;
using RecipeBook.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeBook.Application.Features.Articles.Commands.CreateArticle
{
    public class CreateArticleCommandValidator : AbstractValidator<CreateArtcileCommand>
    {
       

        public CreateArticleCommandValidator()
        {
            

            RuleFor(p => p.ProductId)
                    .NotEmpty()                  
                    .WithMessage("Please select a product");

            RuleFor(p => p.CultureId)
                    .NotEmpty()                    
                    .WithMessage("Please select a culture");

            RuleFor(p => p.GammeId).NotEmpty()
                    .WithMessage("Please select a gamme");

            RuleFor(p => p.SupplierId).NotEmpty()
                    .WithMessage("Please select a supplier");

        }
    }
}
