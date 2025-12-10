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

            // CORREÇÃO 1: Define a coluna Price para usar DECIMAL, compatível com MySQL.
            builder.Property(p => p.Price)
                .IsRequired()
                .HasColumnType("decimal(10, 2)");

            // CORREÇÃO 2: Garante que strings não usem 'NVARCHAR(MAX)'
            builder.Property(p => p.Name)
                .HasMaxLength(255)
                .IsRequired();

            // Configuração da Herança (TPH)
            builder.HasDiscriminator<string>("ProductType")
                .HasValue<Food>("Food")
                .HasValue<DrinkMap>("Drink");
        }
    }
}