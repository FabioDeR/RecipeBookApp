using MediatR;
using RecipeBook.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeBook.Application.Features.Products.Queries.ProductDetail
{
    public class GetProductDetailQueryHandler : IRequestHandler<GetProductDetailQuery, ProductDetailVM>
    {
        public readonly IProductRepository _productRepository;

        public GetProductDetailQueryHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<ProductDetailVM> Handle(GetProductDetailQuery request, CancellationToken cancellationToken)
        {
            ProductDetailVM productDetail = await _productRepository.GetProductDetailWithUnit(request.Id);

            return productDetail;

        }
    }
}
