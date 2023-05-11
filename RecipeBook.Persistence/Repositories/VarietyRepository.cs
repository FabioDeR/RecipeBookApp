using Microsoft.EntityFrameworkCore;
using RecipeBook.Application.Contracts.Persistence;
using RecipeBook.Application.Features.Varieties.Queries.CommonVM;
using RecipeBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeBook.Persitence.Repositories
{
    public class VarietyRepository : BaseRepository<Variety>, IVarietyRepository
    {
        public VarietyRepository(RecipeBookDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<VarietyDetailVM> GetVarietyDetailWithProductInfo(Guid id)
        {
            return await _dbContext.Varieties.Where(e => e.Id == id).Include(p => p.Product).Select(e => new VarietyDetailVM
            {
                Id = e.Id,
                Name = e.Name,
                ProductInfoDto = new ProductInfoDto()
                {
                    Id = e.ProductId,
                    Name = e.Product.Name,
                }

            }).FirstAsync();
        }

        public async Task<List<VarietyDetailVM>> GetVarietyListWithProductInfo()
        {
            return await _dbContext.Varieties.Select(e => new VarietyDetailVM
            {
                Id= e.Id,
                Name= e.Name,
                ProductInfoDto = new ProductInfoDto()
                {
                    Id = e.ProductId,
                    Name = e.Product.Name,
                }

            }).ToListAsync();
        }
    }
}
