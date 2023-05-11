﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeBook.Application.Features.Recipes.Commands.DeleteRecipe
{
    public class DeleteRecipeCommand : IRequest
    {
        public Guid Id { get; set; }
    }
}
