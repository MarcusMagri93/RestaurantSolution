using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Restaurant.Domain.Entities;

namespace Restaurant.Repository.Mapping
{
    public class DrinkMap : IEntityTypeConfiguration<Drink>
    {
        public void Configure(EntityTypeBuilder<Drink> builder)
        {
            // Configurações específicas da entidade Drink

            // Volume é obrigatório
            builder.Property(d => d.Volume)
                .IsRequired();
        }
    }
}