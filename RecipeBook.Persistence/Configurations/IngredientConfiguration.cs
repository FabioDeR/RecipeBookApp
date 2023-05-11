using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RecipeBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeBook.Persitence.Configurations
{
    public class IngredientConfiguration : IEntityTypeConfiguration<Ingredient>
    {
        public void Configure(EntityTypeBuilder<Ingredient> builder)
        {
            builder.HasOne(r => r.Recipe)
                   .WithMany(e => e.Ingredients)
                   .HasForeignKey(r => r.RecipeId);

            builder.HasOne(r => r.Product)
                  .WithMany(e => e.Ingredients)
                  .HasForeignKey(r => r.ProductId);

            builder.HasOne(r => r.Variety)
                  .WithMany(e => e.Ingredients)
                  .HasForeignKey(r => r.VarietyId);

            builder.HasOne(r => r.Unit)
                   .WithMany(e => e.Ingredients)
                   .HasForeignKey(r => r.UnitId);
        }
    }
}
