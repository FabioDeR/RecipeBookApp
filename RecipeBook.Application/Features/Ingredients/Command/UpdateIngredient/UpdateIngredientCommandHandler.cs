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

namespace RecipeBook.Application.Features.Ingredients.Command.UpdateIngredient
{
    public class UpdateIngredientCommandHandler : IRequestHandler<UpdateIngredientCommand>
    {
        private readonly IAsyncRepository<Ingredient> _ingredientRepository;
        private readonly IMapper _mapper;

        public UpdateIngredientCommandHandler(IAsyncRepository<Ingredient> ingredientRepository, IMapper mapper)
        {
            _ingredientRepository = ingredientRepository;
            _mapper = mapper;
        }
        public async Task<Unit> Handle(UpdateIngredientCommand request, CancellationToken cancellationToken)
        {
            var ingredientUpdated = await _ingredientRepository.GetByIdAsync(request.Id);

            if (ingredientUpdated == null)
            {

                throw new NotFoundException(nameof(Gamme), request.Id);

            }
            _mapper.Map(request, ingredientUpdated);

            await _ingredientRepository.UpdateAsync(ingredientUpdated);

            return Unit.Value;
        }
    }
}
