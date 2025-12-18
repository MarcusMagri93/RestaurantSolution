using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Restaurant.Domain.Entities;

namespace Restaurant.Repository.Mapping
{
    public class FoodMap : IEntityTypeConfiguration<Food>
    {
        public void Configure(EntityTypeBuilder<Food> builder)
        {
            // Primary Key
            builder.Property(f => f.Weight)
                .IsRequired();

            builder.Property(f => f.Ingredients)
                .HasMaxLength(500)
                .IsRequired(false);
            }
        }
    }