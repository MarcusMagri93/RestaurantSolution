using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Restaurant.Domain.Entities;

namespace Restaurant.Repository.Mapping
{
    //Define o Nome da Tabela 
    public class DrinkMap : IEntityTypeConfiguration<Drink>
    {
        public void Configure(EntityTypeBuilder<Drink> builder)
        {
            // Primary Key
            builder.Property(d => d.Volume)
                .IsRequired();
        }
    }
}