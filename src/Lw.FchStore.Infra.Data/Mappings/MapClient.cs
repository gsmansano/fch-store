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

            builder.HasKey(c => c.ClientId);

            builder.Property(c => c.ClientId)
                .HasColumnType("int")
                .HasColumnName("ClientId")
                .IsRequired();

            builder.Property(c => c.Fullname)
                .HasColumnType("varchar(255)")
                .HasColumnName("Fullname")
                .IsRequired();

            builder.Property(c => c.Email)
                .HasColumnType("varchar(255)")
                .HasColumnName("Email")
                .IsRequired();

            builder.Property(c => c.DateOfBirth)
                .HasColumnType("datetime")
                .HasColumnName("DateOfBirth")
                .IsRequired();

            builder.Property(c => c.DocumentNumber)
                .HasColumnType("varchar(100)")
                .HasColumnName("DocumentNumber")
                .IsRequired();

            builder.Property(c => c.Gender)
                .HasColumnType("int")
                .HasColumnName("Gender")
                .IsRequired();

            builder.Property(c => c.PhoneNumber)
                .HasColumnType("varchar(20)")
                .HasColumnName("PhoneNumber")
                .IsRequired();

            builder.Property(c => c.IsActive)
                .HasColumnType("bit")
                .HasColumnName("IsActive")
                .IsRequired();

            builder.Property(c => c.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("CreatedAt")
                .IsRequired();


            builder.HasMany<ClientAddress>(p => p.Addresses).WithOne(p => p.Client);
            builder.HasMany<Order>(p => p.Orders).WithOne(p => p.Client);
        }
    }
}
