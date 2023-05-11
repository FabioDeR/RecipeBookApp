using AutoMapper;
using MediatR;
using RecipeBook.Application.Contracts.Persistence;
using RecipeBook.Application.Exceptions;
using RecipeBook.Application.Features.Ingredients.Command.UpdateIngredient;
using RecipeBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeBook.Application.Features.RecipeBooks.Commands.UpdateRecipe
{
    internal class UpdateRecipeCommandHandler : IRequestHandler<UpdateRecipeCommand>
    {

        private readonly IAsyncRepository<Recipe> _recipebookRepository;
        private readonly IMapper _mapper;

        public UpdateRecipeCommandHandler(IAsyncRepository<Recipe> recipebookRepository, IMapper mapper)
        {
            _recipebookRepository = recipebookRepository;
            _mapper = mapper;
        }
        public async Task<Unit> Handle(UpdateRecipeCommand request, CancellationToken cancellationToken)
        {
            var ingredientUpdated = await _recipebookRepository.GetByIdAsync(request.Id);

            if (ingredientUpdated == null)
            {

                throw new NotFoundException(nameof(RecipeBook), request.Id);

            }
            _mapper.Map(request, ingredientUpdated);

            await _recipebookRepository.UpdateAsync(ingredientUpdated);

            return Unit.Value;
        }
    }
}
