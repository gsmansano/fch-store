using Lw.FchStore.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Lw.FchStore.Infra.Data.Mappings
{
    internal class MapProduct : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Product");

            builder.HasKey(p => p.ProductId);

            builder.Property(p => p.ProductId)
                   .HasColumnType("int")
                   .HasColumnName("ProductId")
                   .IsRequired();

            builder.Property(p => p.CategoryId)
                   .HasColumnType("int")
                   .HasColumnName("CategoryId")
                   .IsRequired();

            builder.Property(p => p.SupplierId)
                   .HasColumnType("int")
                   .HasColumnName("SupplierId")
                   .IsRequired();

            builder.Property(p => p.ManufacturerId)
                   .HasColumnType("int")
                   .HasColumnName("ManufacturerId")
                   .IsRequired();

            builder.Property(p => p.UnitId)
                   .HasColumnType("int")
                   .HasColumnName("UnitId")
                   .IsRequired();

            builder.Property(p => p.Name)
                   .HasColumnType("varchar(255)")
                   .HasColumnName("Name")
                   .IsRequired()
                   .HasMaxLength(255);

            builder.Property(p => p.Description)
                   .HasColumnType("varchar(1000)")
                   .HasColumnName("Description")
                   .HasMaxLength(1000);

            builder.Property(p => p.CostPrice)
                   .HasColumnType("decimal(18,2)")
                   .HasColumnName("CostPrice")
                   .IsRequired();

            builder.Property(p => p.SalePrice)
                   .HasColumnType("decimal(18,2)")
                   .HasColumnName("SalePrice")
                   .IsRequired();

            builder.Property(p => p.CreatedAt)
                   .HasColumnType("datetime")
                   .HasColumnName("CreatedAt");

            builder.Property(p => p.IsActive)
                   .HasColumnType("bit")
                   .HasColumnName("IsActive")
                   .HasDefaultValue(true);

        }
    }

}
