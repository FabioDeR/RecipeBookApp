using Microsoft.EntityFrameworkCore;
using RecipeBook.Application.Contracts.Persistence;
using RecipeBook.Application.Features.Products.Queries.ProductDetail;
using RecipeBook.Application.Features.Products.Queries.ProductList;
using RecipeBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeBook.Persitence.Repositories
{
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        public ProductRepository(RecipeBookDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<ProductDetailVM> GetProductDetailWithUnit(Guid id)
        {
            return await _dbContext.Products.Where(e => e.Id == id)
                                            .Include(u => u.Unit)
                                            .Select(x => new ProductDetailVM { Id = x.Id, Name = x.Name, UnitName = x.Unit.Name })
                                            .FirstAsync();
        }

        public async Task<List<ProductListWithUnitVM>> GetProductListWithUnit()
        {
            return await _dbContext.Products.Select(x => new ProductListWithUnitVM
            {
                Id= x.Id,
                Name= x.Name,
                UnitName= x.Unit.Name

            }).ToListAsync();
        }
    }
}
