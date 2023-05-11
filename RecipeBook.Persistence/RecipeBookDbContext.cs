using Microsoft.EntityFrameworkCore;
using RecipeBook.Persitence.SeedData;
using RecipeBook.Application.Contracts.Logged;
using RecipeBook.Domain.Common;
using RecipeBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeBook.Persitence
{
    public class RecipeBookDbContext : DbContext
    {
        //private readonly ILoggedInUserService _loggedInUserService;

        public RecipeBookDbContext(DbContextOptions<RecipeBookDbContext> options/*ILoggedInUserService loggedInUserService*/) : base(options)
        {
            //_loggedInUserService = loggedInUserService;
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Cut> Cuts { get; set; }
        public DbSet<Gamme> Gammes { get; set; }
        public  DbSet<Product> Products { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Culture> Cultures { get; set; }
        public DbSet<UnitOfMeasurement> UnitOfMeasurements { get; set; }
        public DbSet<Variety> Varieties { get; set; }
        public DbSet<Article> Articles { get; set; }
        public DbSet<Recipe> Recipes { get; set; }        
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<Shift> Shifts { get; set; }
       

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(RecipeBookDbContext).Assembly);

            modelBuilder.SeedData();            
        }

         

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries<AuditableEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreationDate = DateTime.Now;
                        entry.Entity.CreationTrackingUserId = Guid.Parse("6d6e284c-1278-4b9d-ba98-1d37bc941617");
                        break;
                    case EntityState.Modified:
                        entry.Entity.UpdateDate = DateTime.Now;
                        entry.Entity.UpdateTrackingUserId = Guid.Parse("6d6e284c-1278-4b9d-ba98-1d37bc941617");
                        break;
                    case EntityState.Deleted:
                        entry.Entity.DeleteDate = DateTime.Now;
                        entry.Entity.DeleteTrackingUserId = Guid.Parse("6d6e284c-1278-4b9d-ba98-1d37bc941617");
                        break;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }



    }
}
