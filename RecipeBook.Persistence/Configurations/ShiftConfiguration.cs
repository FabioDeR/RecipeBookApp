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
    public class ShiftConfiguration : IEntityTypeConfiguration<Shift>
    {
        public void Configure(EntityTypeBuilder<Shift> builder)
        {
            builder.HasOne(r => r.Recipe)
                   .WithMany(e => e.Shifts)
                   .HasForeignKey(r => r.RecipeBookId);

            builder.HasOne(e => e.Unit)
                .WithMany(e => e.Shifts)
                .HasForeignKey(e => e.UnitId);

            builder.HasOne(e => e.StatementRecipe)
                   .WithMany(e => e.Shifts)
                   .HasForeignKey(e => e.StatementRecipeId);

        }
    }
}
