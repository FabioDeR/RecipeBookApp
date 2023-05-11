using MediatR;
using RecipeBook.Application.Contracts.Persistence;
using RecipeBook.Application.Exceptions;
using RecipeBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeBook.Application.Features.Categories.Commands.DeleteCategory
{
    public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand>
    {
        public readonly IAsyncRepository<Category> _categoryRepository;

        public DeleteCategoryCommandHandler(IAsyncRepository<Category> categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<MediatR.Unit> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            var categoryDeleted = await _categoryRepository.GetByIdAsync(request.CategoryId);

            if (categoryDeleted == null)
            {
                throw new NotFoundException(nameof(Category), request.CategoryId);
            }

            await _categoryRepository.DeleteAsync(categoryDeleted);

            return MediatR.Unit.Value;
        }
    }
}
