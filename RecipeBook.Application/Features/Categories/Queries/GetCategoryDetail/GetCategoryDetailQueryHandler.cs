using AutoMapper;
using MediatR;
using RecipeBook.Application.Contracts.Persistence;
using RecipeBook.Application.Exceptions;
using RecipeBook.Application.Features.Categories.Queries.CommonVM;
using RecipeBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeBook.Application.Features.Categories.Queries.GetCategoryDetail
{
    public class GetCategoryDetailQueryHandler : IRequestHandler<GetCategoryDetailQuery, CategoryVM>
    {
        public readonly ICategoryRepository _categoryRepository;
        public readonly IMapper _mapper;

        public GetCategoryDetailQueryHandler(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }
        public async Task<CategoryVM> Handle(GetCategoryDetailQuery request, CancellationToken cancellationToken)
        {
            var categoryDetail = await _categoryRepository.GetByIdAsync(request.Id);
            if (categoryDetail == null)
            {
                throw new NotFoundException(nameof(Category), request.Id);
            }

            return _mapper.Map<CategoryVM>(categoryDetail);

        }
    }
}
