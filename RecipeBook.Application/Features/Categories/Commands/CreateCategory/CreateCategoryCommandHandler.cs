using AutoMapper;
using MediatR;
using RecipeBook.Application.Contracts.Persistence;
using RecipeBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeBook.Application.Features.Categories.Commands.CreateCategory
{
    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, CreateCategoryCommandResponse>
    {
        private readonly IAsyncRepository<Category> _categoryRepository;
        private readonly IMapper _mapper;

        public CreateCategoryCommandHandler(IMapper mapper, IAsyncRepository<Category> categoryRepository)
        {
            _mapper = mapper;
            _categoryRepository = categoryRepository;
        }

        public async Task<CreateCategoryCommandResponse> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            var createCategoryCommandResponse = new CreateCategoryCommandResponse();
            var validator = new CreateCategoryCommandValidator();
            var validatorResult = await validator.ValidateAsync(request);

            if(validatorResult.Errors.Count > 0) {
                createCategoryCommandResponse.Success = false;

                createCategoryCommandResponse.ValidationErrors = new List<string>();

                foreach (var error in validatorResult.Errors)
                {
                    createCategoryCommandResponse.ValidationErrors.Add(error.ErrorMessage);
                }            
            }
            if(createCategoryCommandResponse.Success)
            {
                var category = new Category()
                {
                    Name = request.Name,
                };
                category = await _categoryRepository.AddAsync(category);

                createCategoryCommandResponse.Category = _mapper.Map<CreateCategoryDto>(category);
            }
            return createCategoryCommandResponse;
        }
    }
}
