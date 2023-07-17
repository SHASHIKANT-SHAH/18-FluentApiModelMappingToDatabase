using DAL.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(p => p.Id).HasName("product_id_key");

            builder.Property(p => p.Id).HasColumnName("product_id").IsRequired();
            builder.Property(p => p.Name).IsRequired().HasMaxLength(100);
            builder.Property(p => p.Price).HasColumnType("decimal(18,2)");

            builder.ToTable("productInfo");
            //other configuration
            //builder.HasIndex(p => p.Name).IsUnique    
            //builder.HasOne(p => p.Category).WithMany(c => c.Products).HasForeignKey(p => p.CategoryId);
            //builder.ToTable("CustomTableName");
            //builder.Ignore(p => p.Discontinued);

        }
    }
}
