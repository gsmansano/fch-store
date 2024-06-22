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

            builder.Property(c => c.CategoryId).HasColumnType("int").HasColumnName("CategoryId").IsRequired();
            builder.Property(c => c.Name).HasColumnType("varchar(500)").HasColumnName("Name");
            builder.Property(c => c.IsActive).HasColumnType("bit").HasColumnName("IsActive");
        }
    }
}
