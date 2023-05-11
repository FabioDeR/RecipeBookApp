using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.Logging;
using RecipeBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeBook.Persitence.Configurations
{
    public class ArticleConfiguration : IEntityTypeConfiguration<Article>
    {
        public void Configure(EntityTypeBuilder<Article> builder)
        {
            builder.HasOne<Category>(e => e.Category)
                   .WithMany(d => d.Articles)
                   .HasForeignKey(e => e.CategoryId);

            builder.HasOne<Product>(e => e.Product)
                   .WithMany(d => d.Articles)
                   .HasForeignKey(e => e.ProductId);

            builder.HasOne<Culture>(e => e.Culture)
                    .WithMany(e => e.Articles)
                    .HasForeignKey(e => e.CultureId);

            builder.HasOne<Gamme>(e => e.Gamme)
                   .WithMany(e => e.Articles)
                   .HasForeignKey(e => e.GammeId);


            builder.HasOne<Supplier>(e => e.Supplier)
                   .WithMany(e => e.Articles)
                   .HasForeignKey(e => e.SupplierId);

            builder.HasOne<Cut>(e => e.Cut)
                   .WithMany(e => e.Articles)
                   .HasForeignKey(e => e.CutId);

            builder.HasOne<Variety>(e => e.Variety)
              .WithMany(e => e.Articles)
              .HasForeignKey(e => e.VarietyId);

        }
    }
}
