using AutoMapper;
using MediatR;
using RecipeBook.Application.Contracts.Persistence;
using RecipeBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeBook.Application.Features.Ingredients.Queries.IngredientDetail
{
    public class GetIngredientDetailQueryHandler : IRequestHandler<GetIngredientDetailQuery, IngredientVM>
    {

        public readonly IAsyncRepository<Ingredient> _ingredientRepository;
        public readonly IMapper _mapper;

        public GetIngredientDetailQueryHandler(IAsyncRepository<Ingredient> ingredientRepository, IMapper mapper)
        {
            _ingredientRepository = ingredientRepository;
            _mapper = mapper;
        }


        public async Task<IngredientVM> Handle(GetIngredientDetailQuery request, CancellationToken cancellationToken)
        {
            
            return _mapper.Map<IngredientVM>(await _ingredientRepository.GetByIdAsync(request.Id));
        }
    }
}
