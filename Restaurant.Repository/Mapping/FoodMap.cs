using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Restaurant.Domain.Entities;

namespace Restaurant.Repository.Mapping
{
    public class FoodMap : IEntityTypeConfiguration<Food>
    {
        public void Configure(EntityTypeBuilder<Food> builder)
        {
            // Configurações específicas da entidade Food

            // Peso é obrigatório
            builder.Property(f => f.Weight)
                .IsRequired();

            // Ingredientes: Define um tamanho máximo para não ficar como 'longtext' desnecessariamente
            builder.Property(f => f.Ingredients)
                .HasMaxLength(500)
                .IsRequired(false);
            }
        }
    }