using Microsoft.EntityFrameworkCore;
using RecipeBook.Application.Contracts.Logged;
using RecipeBook.Application.Contracts.Persistence;
using RecipeBook.Application.Features.Ingredients.Queries.IngredientDetail;
using RecipeBook.Application.Features.Ingredients.Queries.IngredientList;
using RecipeBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeBook.Persitence.Repositories
{
    public class IngredientRepository : BaseRepository<Ingredient>, IIngredientRepository
    {
        public IngredientRepository(RecipeBookDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<List<IngredientListByRecipeBookVM>> GetIngredientListByRecipeBook(Guid recipeBookId)
        {
            return await _dbContext.Ingredients.Where(r => r.RecipeId == recipeBookId)
                                               .Include(p => p.Product)
                                               .Include(v => v.Unit)
                                               .Include(x => x.Variety)
                                               .Select(x => new IngredientListByRecipeBookVM()
                                               {
                                                   ProductName = x.Product.Name,
                                                   UnitName = x.Unit.Name,
                                                   Quantity = x.Quantity,
                                                   VarietyName = x.Variety.Name,

                                               }).ToListAsync();
        }


        public override async Task<Ingredient> GetByIdAsync(Guid id)
        {
            var ingredient = await (from ing in _dbContext.Ingredients
                                     join prod in _dbContext.Products
                                     on ing.ProductId equals prod.Id
                                     join recipe in _dbContext.Recipes
                                     on ing.RecipeId equals recipe.Id
                                     join unit in _dbContext.UnitOfMeasurements
                                     on ing.UnitId equals unit.Id
                                     join variety in _dbContext.Varieties
                                     on ing.VarietyId equals variety.Id
                                     select new Ingredient()
                                     {
                                         VarietyId = ing.VarietyId,
                                         Product = new Product
                                         {
                                             Name = ing.Product.Name,
                                         },
                                         RecipeId= ing.RecipeId,
                                         Recipe = new Recipe()
                                         {
                                             Name= ing.Recipe.Name,
                                         },
                                         Variety = new Variety()
                                         {
                                             Name = ing.Variety.Name,
                                         },
                                         Quantity= ing.Quantity,
                                         Unit = new UnitOfMeasurement()
                                         {
                                             Name= ing.Unit.Name,
                                         }               


                                     }).FirstOrDefaultAsync();
            return ingredient;







        }
    }
}
