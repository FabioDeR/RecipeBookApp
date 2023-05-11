using AutoMapper;
using FluentValidation;
using MediatR;
using RecipeBook.Application.Contracts.Persistence;
using RecipeBook.Application.Features.Gammes.Commands.CreateGamme;
using RecipeBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeBook.Application.Features.Suppliers.Commands.CreateSupplier
{
    public class CreateSupplierCommandValidator : AbstractValidator<CreateSupplierCommand>
    {
        public CreateSupplierCommandValidator()
        {

            RuleFor(p => p.Name)
                    .NotEmpty().WithMessage("{PropertyName} is required")
                    .NotNull()
                    .MaximumLength(50).WithMessage("{PropertyName} must not exceed 10 characters ");
        }
    }
}
