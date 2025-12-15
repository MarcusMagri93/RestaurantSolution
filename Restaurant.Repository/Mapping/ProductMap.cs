using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Restaurant.Domain.Entities;

namespace Restaurant.Repository.Mapping
{
    public class ProductMap : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Products");
            builder.HasKey(p => p.Id);

            // --- CRUCIAL: TRAVA DE UNICIDADE ---
            // Cria um índice único para o Nome. O banco rejeitará duplicatas.
            builder.HasIndex(p => p.Name)
                .IsUnique();

            builder.Property(p => p.Price)
                .IsRequired()
                .HasColumnType("decimal(10, 2)");

            builder.Property(p => p.Name)
                .HasMaxLength(255)
                .IsRequired();

            // Configuração da Herança (TPH)
            builder.HasDiscriminator<string>("ProductType")
                .HasValue<Food>("Food")
                .HasValue<Drink>("Drink");
        }
    }
}