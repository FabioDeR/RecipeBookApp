using Microsoft.EntityFrameworkCore;
using RecipeBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeBook.Persitence.SeedData
{
    public static class OnModelCreatingExtension
    {

        public static void SeedData(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StatementRecipe>().HasData(
               new StatementRecipe { Id = Guid.NewGuid(), Name = "En attente" },
               new StatementRecipe { Id = Guid.NewGuid(), Name = "En cours" },
               new StatementRecipe { Id = Guid.NewGuid(), Name = "Fait" },
               new StatementRecipe { Id = Guid.NewGuid(), Name = "Annulée" }
           );

            modelBuilder.Entity<Gamme>().HasData(
              new Gamme { Id = Guid.NewGuid(), Name = "Brut" },
              new Gamme { Id = Guid.NewGuid(), Name = "Congelé" },
              new Gamme { Id = Guid.NewGuid(), Name = "Sous-vide" },
              new Gamme { Id = Guid.NewGuid(), Name = "Vente Direct" }
          );

           


        }
    }
}
