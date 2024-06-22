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

            builder.Property(c => c.ProductId).HasColumnType("int").HasColumnName("ProductId").IsRequired();
            builder.Property(c => c.CategoryId).HasColumnType("int").HasColumnName("CategoryId").IsRequired();
            builder.Property(c => c.SupplierId).HasColumnType("int").HasColumnName("SupplierId").IsRequired();
            builder.Property(c => c.ManufacturerId).HasColumnType("int").HasColumnName("ManufacturerId").IsRequired();
            builder.Property(c => c.UnitId).HasColumnType("int").HasColumnName("UnitId").IsRequired();
            builder.Property(c => c.Name).HasColumnType("string").HasColumnName("Name");
            builder.Property(c => c.Description).HasColumnType("string").HasColumnName("Description");
            builder.Property(c => c.CostPrice).HasColumnType("decimal").HasColumnName("CostPrice");
            builder.Property(c => c.SalePrice).HasColumnType("decimal").HasColumnName("SalePrice");
            builder.Property(c => c.CreatedAt).HasColumnType("datetime").HasColumnName("CreatedAt");
            builder.Property(c => c.IsActive).HasColumnType("bool").HasColumnName("CreatedAt");

    }
    }

}
