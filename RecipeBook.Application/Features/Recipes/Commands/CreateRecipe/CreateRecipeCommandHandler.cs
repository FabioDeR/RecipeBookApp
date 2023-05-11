using AutoMapper;
using MediatR;
using RecipeBook.Application.Contracts.Persistence;
using RecipeBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeBook.Application.Features.Recipes.Commands.CreateRecipe
{
    internal class CreateRecipeCommandHandler : IRequestHandler<CreateRecipeCommand, CreateRecipeCommandResponse>
    {

        private readonly IAsyncRepository<Recipe> _recipeBookRepository;
        private readonly IMapper _mapper;
        
        public CreateRecipeCommandHandler(IAsyncRepository<Recipe> recipeBookRepository, IMapper mapper)
        {
            _recipeBookRepository = recipeBookRepository;
            _mapper = mapper;
        }

        public async Task<CreateRecipeCommandResponse> Handle(CreateRecipeCommand request, CancellationToken cancellationToken)
        {
            var createRecipeBookValidator = new CreateRecipeCommandValidator();
            var createRecipeBookResponse = new CreateRecipeCommandResponse();


            var createRecipeBookResult = await createRecipeBookValidator.ValidateAsync(request);

            if(createRecipeBookResult.Errors.Count > 0)
            {
                createRecipeBookResponse.Success = false;

                createRecipeBookResponse.ValidationErrors = new List<string>();

                foreach(var errors  in createRecipeBookResult.Errors)
                {
                    createRecipeBookResponse.ValidationErrors.Add(errors.ErrorMessage);
                }
            }

            if(createRecipeBookResponse.Success)
            {
                var newRecipeBook = new Recipe()
                {
                    Comment= request.Comment,
                    CultureId= request.CultureId,
                    Name= request.Name,
                    ProductId= request.ProductId,
                    CutId= request.CutId,   
                    Quantity= request.Quantity,
                    UnitId= request.UnitId, 
                };
                newRecipeBook = await _recipeBookRepository.AddAsync(newRecipeBook);
                createRecipeBookResponse.RecipeBookDto = _mapper.Map<RecipeDto>(newRecipeBook);
            }

            return createRecipeBookResponse;
            
        }
    }
}
