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

            // --- CONFIGURAÇÃO DE ID COM AUTO INCREMENTO ---
            builder.HasKey(w => w.Id);
            builder.Property(w => w.Id)
                .ValueGeneratedOnAdd(); // Garante que o banco gere o ID sequencialmente

            builder.HasIndex(w => w.Registration)
                .IsUnique();

            // Configurações de propriedades
            builder.Property(w => w.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(w => w.Registration)
                .IsRequired()
                .HasMaxLength(50);

            // Relacionamentos
            builder.HasMany(w => w.Orders)
                .WithOne(o => o.Waiter)
                .HasForeignKey(o => o.WaiterId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}