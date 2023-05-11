using AutoMapper;
using MediatR;
using RecipeBook.Application.Contracts.Persistence;
using RecipeBook.Application.Exceptions;
using RecipeBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeBook.Application.Features.Recipes.Commands.DeleteRecipe
{
    public class DeleteRecipeCommandHandler : IRequestHandler<DeleteRecipeCommand>
    {
        private readonly IAsyncRepository<Recipe> _recipeBookRepository;
       

        public DeleteRecipeCommandHandler(IAsyncRepository<Recipe> recipeBookRepository)
        {
            _recipeBookRepository = recipeBookRepository;
            
        }


        async Task<Unit> IRequestHandler<DeleteRecipeCommand, Unit>.Handle(DeleteRecipeCommand request, CancellationToken cancellationToken)
        {
            var categoryDeleted = await _recipeBookRepository.GetByIdAsync(request.Id);

            if (categoryDeleted == null)
            {
                throw new NotFoundException(nameof(RecipeBook), request.Id);
            }

            await _recipeBookRepository.DeleteAsync(categoryDeleted);

            return MediatR.Unit.Value;
        }
    }
}
