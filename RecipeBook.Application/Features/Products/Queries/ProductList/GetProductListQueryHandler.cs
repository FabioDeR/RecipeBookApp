using MediatR;
using RecipeBook.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeBook.Application.Features.Products.Queries.ProductList
{
    public class GetProductListQueryHandler : IRequestHandler<GetProductListQuery, List<ProductListWithUnitVM>>
    {
        public readonly IProductRepository _productRepository;

        public GetProductListQueryHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public Task<List<ProductListWithUnitVM>> Handle(GetProductListQuery request, CancellationToken cancellationToken)
        {
            return _productRepository.GetProductListWithUnit();
        }
    }
}
