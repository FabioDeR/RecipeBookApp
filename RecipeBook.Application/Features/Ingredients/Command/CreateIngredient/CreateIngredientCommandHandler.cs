using AutoMapper;
using MediatR;
using RecipeBook.Application.Contracts.Persistence;
using RecipeBook.Application.Features.Gammes.Commands.CreateGamme;
using RecipeBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeBook.Application.Features.Ingredients.Command.CreateIngredient
{
    public class CreateIngredientCommandHandler : IRequestHandler<CreateIngredientCommand, CreateIngredientCommandResponse>
    {
        public readonly IAsyncRepository<Ingredient> _ingredientRepository;
        public readonly IMapper _mapper;

        public CreateIngredientCommandHandler(IAsyncRepository<Ingredient> ingredientRepository, IMapper mapper)
        {
            _ingredientRepository = ingredientRepository;
            _mapper = mapper;
        }

        public async Task<CreateIngredientCommandResponse> Handle(CreateIngredientCommand request, CancellationToken cancellationToken)
        {
            var createIngredientResponse = new CreateIngredientCommandResponse();
            var createIngredientValidator = new CreateIngredientCommandValidator();

            var resultGammmeValidator = await createIngredientValidator.ValidateAsync(request);

            if (resultGammmeValidator.Errors.Count > 0)
            {
                createIngredientResponse.Success = false;
                createIngredientResponse.ValidationErrors = new List<string>();

                foreach (var errors in resultGammmeValidator.Errors)
                {
                    createIngredientResponse.ValidationErrors.Add(errors.ErrorMessage);
                }

            }

            if (createIngredientResponse.Success)
            {
                var resultMapIngredient = _mapper.Map<Ingredient>(request);

                var newIngredient = await _ingredientRepository.AddAsync(resultMapIngredient);

                createIngredientResponse.IngredientDto = _mapper.Map<IngredientDto>(newIngredient);
            }

            return createIngredientResponse;
        }
    }
}
