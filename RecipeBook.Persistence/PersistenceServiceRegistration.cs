using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RecipeBook.Persitence.Repositories;
using RecipeBook.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeBook.Persitence
{
    public static class PersistenceServiceRegistration
    {

        public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<RecipeBookDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("RecipeDbContextConnectionString")));
            services.AddScoped(typeof(IAsyncRepository<>), typeof(BaseRepository<>));
            services.AddScoped<IArticleRepository, ArticleRepository>();         
            services.AddScoped<ICategoryRepository, CategoryRepository>();          
            services.AddScoped<IVarietyRepository, VarietyRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IRecipeRepository, RecipeRepository>();
            services.AddScoped<IIngredientRepository, IngredientRepository>();


            return services;
        }
    }
}
