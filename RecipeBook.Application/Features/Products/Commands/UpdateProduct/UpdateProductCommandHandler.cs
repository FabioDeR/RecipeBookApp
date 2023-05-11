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

namespace RecipeBook.Application.Features.Products.Commands.UpdateProduct
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand>
    {
        public readonly IAsyncRepository<Product> _productRepository;
        public readonly IMapper _mapper;

        public UpdateProductCommandHandler(IAsyncRepository<Product> productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var productUpdated = await _productRepository.GetByIdAsync(request.Id);

            if (productUpdated == null)
            {
                throw new NotFoundException(nameof(Product), request.Id);
            }

            _mapper.Map(request, productUpdated);

            await _productRepository.UpdateAsync(productUpdated);

            return Unit.Value;
        }
    }
}
