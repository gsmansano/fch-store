using Lw.FchStore.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lw.FchStore.Infra.Data.Mappings
{
    internal class MapCategory : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable("Category");

            builder.HasKey(c => c.CategoryId);

            builder.Property(c => c.CategoryId)
                   .HasColumnType("int")
                   .HasColumnName("CategoryId")
                   .IsRequired();

            builder.Property(c => c.Name)
                   .HasColumnType("varchar(500)")
                   .HasColumnName("Name")
                   .IsRequired()
                   .HasMaxLength(500);

            builder.Property(c => c.Description)
                   .HasColumnType("varchar(500)")
                   .HasColumnName("Description")
                   .HasMaxLength(500);

            builder.Property(c => c.IsActive)
                   .HasColumnType("bit")
                   .HasColumnName("IsActive")
                   .HasDefaultValue(true);

            builder.Property(c => c.ParentId)
                   .HasColumnType("int")
                   .HasColumnName("ParentId");

        }
    }
}
