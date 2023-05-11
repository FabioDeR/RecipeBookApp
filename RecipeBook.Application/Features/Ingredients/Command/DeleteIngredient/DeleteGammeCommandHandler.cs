using MediatR;
using RecipeBook.Application.Contracts.Persistence;
using RecipeBook.Application.Exceptions;
using RecipeBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeBook.Application.Features.Ingredients.Command.DeleteIngredient
{
    public class DeleteIngredientCommandHandler : IRequestHandler<DeleteIngredientCommand>
    {
        private readonly IAsyncRepository<Ingredient> _ingredientRepository;

        public DeleteIngredientCommandHandler(IAsyncRepository<Ingredient> ingredientRepository)
        {
            _ingredientRepository = ingredientRepository;
        }
        public async Task<Unit> Handle(DeleteIngredientCommand request, CancellationToken cancellationToken)
        {
            var gammedeleted = await _ingredientRepository.GetByIdAsync(request.Id);

            if (gammedeleted == null)
            {
                throw new NotFoundException(nameof(Gamme), request.Id);
            }

            await _ingredientRepository.DeleteAsync(gammedeleted);

            return MediatR.Unit.Value;
        }
    }
}
