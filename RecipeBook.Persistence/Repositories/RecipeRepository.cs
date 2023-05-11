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

        public async Task<List<RecipeVM>> GetListRecipeBook()
        {
            return await _dbContext.Recipes
                         .Include(p => p.Product)
                         .ThenInclude(p => p.Unit).Select(p => new RecipeVM()
                         {
                             Id = p.Id,
                             Name = p.Name,
                             ProductName = p.Product.Name,
                             UnitName = p.Unit.Name,
                             Quantity = p.Quantity,

                         }).ToListAsync();
        }
    }
}
