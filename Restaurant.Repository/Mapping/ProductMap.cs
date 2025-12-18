using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Restaurant.Domain.Entities;

namespace Restaurant.Repository.Mapping
{
    public class ProductMap : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            // Nome da Tabela 
            builder.ToTable("Products");
            // Primary Key
            builder.HasKey(p => p.Id);

            // Evita Nome Repetido
            builder.HasIndex(p => p.Name)
                .IsUnique();

            builder.Property(p => p.Price)
                .IsRequired()
                .HasColumnType("decimal(10, 2)");

            builder.Property(p => p.Name)
                .HasMaxLength(255)
                .IsRequired();

            // Configuração da Herança 
            builder.HasDiscriminator<string>("ProductType")
                .HasValue<Food>("Food")
                .HasValue<Drink>("Drink");
        }
    }
}