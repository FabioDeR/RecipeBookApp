using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using RecipeBook.API.Services;
using RecipeBook.Application;
using RecipeBook.Application.Contracts.Logged;
using RecipeBook.Identity;
using RecipeBook.Persitence;

namespace RecipeBook.API
{
    public static class StartupExtensions
    {
        public static WebApplication ConfigurationService(this WebApplicationBuilder builder)
        {
            AddSwagger(builder.Services);
            builder.Services.AddApplicationServices();            
            builder.Services.AddPersistenceServices(builder.Configuration);
            builder.Services.AddIdentityServices(builder.Configuration);
            //builder.Services.AddScoped<ILoggedInUserService, LoggedInUserService>();
            builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            builder.Services.AddHttpContextAccessor();


            builder.Services.AddControllers();

            builder.Services.AddCors(options =>
            {
                options.AddPolicy("Open", builder => builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
            });

            return builder.Build();

        }

        public static WebApplication ConfigurationPipeline(this WebApplication app)
        {
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "RecipeBook API");
                });
            }

            app.UseHttpsRedirection();
            app.UseSwagger();
            //app.UseRouting();

            app.UseAuthentication();

            app.UseCors("Open");

            app.UseAuthorization();

            app.MapControllers();

            return app;
        }
        private static void AddSwagger(IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "RecipeBook API",

                });     
                
            });
        }
        public static async Task ResetDataBaseAsync(this WebApplication app)
        {
            using var scope = app.Services.CreateScope();
            try
            {
                var context = scope.ServiceProvider.GetService<RecipeBookDbContext>();
                if (context != null)
                {
                    await context.Database.EnsureCreatedAsync();
                    await context.Database.MigrateAsync();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
