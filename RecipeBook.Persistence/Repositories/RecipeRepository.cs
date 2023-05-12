using Microsoft.EntityFrameworkCore;
using RecipeBook.Application.Contracts.Persistence;
using RecipeBook.Application.Features.Recipes.Queries.CommonVM;
using RecipeBook.Domain.Entities;

namespace RecipeBook.Persitence.Repositories
{
    public class RecipeRepository : BaseRepository<Recipe>, IRecipeRepository
    {
        public RecipeRepository(RecipeBookDbContext dbContext) : base(dbContext)
        {
        }

        public async override Task<Recipe> GetByIdAsync(Guid id)
        {
            Recipe recipe = await _dbContext.Recipes.Where(r => r.Id == id)
                         .Include(c => c.Culture)
                         .Include(p => p.Product)
                         .ThenInclude(p => p.Unit).Select(r => new Recipe()
                         {
                             Id = r.Id,
                             Name = r.Name,
                             Culture =  new Culture()
                             {
                                 Name = r.Culture.Name,
                             },
                             CultureId = r.CultureId,
                             Product = new Product()
                             {
                                 Name = r.Product.Name,
                             },
                             ProductId = r.ProductId,
                             Unit = new UnitOfMeasurement()
                             {
                                 Name = r.Unit.Name,
                             },
                             UnitId = r.Unit.Id,                             
                             Quantity = r.Quantity,
                             Comment = r.Comment,

                         }).FirstOrDefaultAsync();
            return recipe;
        }

        public async Task<List<RecipeVM>> GetListRecipeBook()
        {
            return await _dbContext.Recipes                        
                         .Include(c => c.Culture)
                         .Include(p => p.Product)
                         .ThenInclude(p => p.Unit).Select(r => new RecipeVM()
                         {
                             Id = r.Id,
                             Name = r.Name,
                             CultureId = r.CultureId,
                             CultureName = r.Culture.Name,
                             ProductId = r.ProductId,
                             ProductName = r.Product.Name,
                             UnitId = r.Unit.Id,
                             UnitName = r.Unit.Name,
                             Quantity = r.Quantity,
                             Comment = r.Comment,

                         }).ToListAsync();
        }
    }
}
