using RecipeBook.Application.Features.Products.Queries.ProductDetail;
using RecipeBook.Application.Features.Products.Queries.ProductList;
using RecipeBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeBook.Application.Contracts.Persistence
{
    public interface IProductRepository : IAsyncRepository<Product>
    {
        Task<ProductDetailVM> GetProductDetailWithUnit(Guid id);
        Task<List<ProductListWithUnitVM>> GetProductListWithUnit();
    }
}
