using AutoMapper;
using MediatR;
using RecipeBook.Application.Contracts.Persistence;
using RecipeBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeBook.Application.Features.Products.Commands.CreateProduct
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, CreateProductCommandResponse>
    {
        public readonly IAsyncRepository<Product> _productRepository;
        public readonly IMapper _mapper;

        public CreateProductCommandHandler(IAsyncRepository<Product> productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<CreateProductCommandResponse> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var createProductValidator = new CreateProductCommandValidator();
            var createProductResponse = new CreateProductCommandResponse();

            var createProductResult = await createProductValidator.ValidateAsync(request);

            if (createProductResult.Errors.Count() > 0)
            {
                createProductResponse.Success = false;
                createProductResponse.ValidationErrors = new List<string>();

                foreach (var errors in createProductResult.Errors)
                {
                    createProductResponse.ValidationErrors.Add(errors.ErrorMessage);
                }
            }

            if (createProductResponse.Success)
            {
                var product = new Product()
                {
                    Name = request.Name,
                    UnitId = request.UnitId,
                };

                product = await _productRepository.AddAsync(product);
                createProductResponse.ProductDto = _mapper.Map<ProductDto>(product);

            }

            return createProductResponse;

        }
    }
}
