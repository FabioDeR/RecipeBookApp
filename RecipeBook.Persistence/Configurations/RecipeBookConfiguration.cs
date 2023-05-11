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
    public class RecipeBookConfiguration : IEntityTypeConfiguration<Recipe>
    {
        public void Configure(EntityTypeBuilder<Recipe> builder)
        {
            builder.HasOne(e => e.Culture)
                   .WithMany(e => e.Recipes)
                   .HasForeignKey(e => e.CultureId);            

            builder.HasOne(e => e.Unit)
                  .WithMany(e => e.Recipes)
                  .HasForeignKey(e => e.UnitId);

            builder.HasOne(e => e.Culture)
                   .WithMany(e => e.Recipes)
                   .HasForeignKey(e => e.CultureId);

            builder.HasOne(e => e.Cut)
                   .WithMany(e => e.Recipes)
                   .HasForeignKey(e => e.CutId);


        }
    }
}
