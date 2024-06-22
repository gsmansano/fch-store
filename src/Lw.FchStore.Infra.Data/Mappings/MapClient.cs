using Lw.FchStore.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Lw.FchStore.Infra.Data.Mappings
{
    internal class MapClient : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            builder.ToTable("Client");

            builder.Property(c => c.ClientId).HasColumnType("int").HasColumnName("CategoryId").IsRequired();
            builder.Property(c => c.Name).HasColumnType("varchar(500)").HasColumnName("Name");
            builder.Property(c => c.IsActive).HasColumnType("bit").HasColumnName("IsActive");
            builder.Property(c => c.CreatedAt).HasColumnType("datetime").HasColumnName("CreatedAt");
        }
    }
}
