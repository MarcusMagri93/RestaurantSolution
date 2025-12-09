using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Restaurant.Domain.Entities;

namespace Restaurant.Repository.Mapping
{
    public class WaiterMap : IEntityTypeConfiguration<Waiter>
    {
        public void Configure(EntityTypeBuilder<Waiter> builder)
        {
            builder.ToTable("Waiters");
            builder.HasKey(w => w.Id);

            // Relacionamento 1:N (Um Waiter tem muitas Orders)
            builder.HasMany(w => w.Orders)
                .WithOne(o => o.Waiter)
                .HasForeignKey(o => o.WaiterId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict); // Padrão PetShop
        }
    }
}