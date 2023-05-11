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

namespace RecipeBook.Application.Features.Products.Commands.DeleteProduct
{
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand>
    {
        public readonly IAsyncRepository<Product> _productRepository;
        public readonly IMapper _mapper;

        public DeleteProductCommandHandler(IAsyncRepository<Product> productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }
        public async Task<Unit> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            var productDeleted = await _productRepository.GetByIdAsync(request.Id);

            if (productDeleted == null)
            {
                throw new NotFoundException(nameof(Product), request.Id);
            }

            await _productRepository.DeleteAsync(productDeleted);

            return Unit.Value;
        }
    }
}
