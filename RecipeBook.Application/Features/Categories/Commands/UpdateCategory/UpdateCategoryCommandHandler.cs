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

namespace RecipeBook.Application.Features.Categories.Commands.UpdateCategory
{
    public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand>
    {
        public readonly IAsyncRepository<Category> _categoryRepository;
        public readonly IMapper _mapper;

        public UpdateCategoryCommandHandler(IAsyncRepository<Category> categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<MediatR.Unit> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            var categoryUpdated = await _categoryRepository.GetByIdAsync(request.Id);
            if (categoryUpdated == null) { 
                    throw new NotFoundException(nameof(Category),request.Id);
            }
            _mapper.Map(request, categoryUpdated,typeof(UpdateCategoryCommand),typeof(Category));

            await _categoryRepository.UpdateAsync(categoryUpdated);

            return MediatR.Unit.Value;  

        }
    }
}
