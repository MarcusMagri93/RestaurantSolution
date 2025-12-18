using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Restaurant.Domain.Entities;

namespace Restaurant.Repository.Mapping
{
    public class OrderMap : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            //Primary Key
            builder.ToTable("Orders");
            builder.HasKey(o => o.Id);

            // Relacionamento N:1 (Waiter)
            builder.HasOne(o => o.Waiter)
                .WithMany(w => w.Orders)
                .HasForeignKey(o => o.WaiterId)
                .IsRequired();

            // Relacionamento 1:N com OrderItem 
            builder.HasMany(o => o.OrderItems)
                .WithOne(oi => oi.Order)
                .HasForeignKey(oi => oi.OrderId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}