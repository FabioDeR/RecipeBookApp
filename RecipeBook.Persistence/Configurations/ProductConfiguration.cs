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
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasOne(e => e.Unit)
                   .WithMany(e => e.Products)
                   .HasForeignKey(e => e.UnitId);

            builder.HasMany(e => e.Varieties)
                   .WithOne(e => e.Product)
                   .HasForeignKey(e => e.ProductId);

        }
    }
}
