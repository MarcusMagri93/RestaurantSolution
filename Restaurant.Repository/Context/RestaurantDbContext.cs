using Microsoft.EntityFrameworkCore;
using Restaurant.Domain.Entities;

namespace Restaurant.Repository.Context
{
    public class RestaurantDbContext : DbContext
    {
        // Construtor que o EF Core usará para configurar a conexão.
        public RestaurantDbContext(DbContextOptions<RestaurantDbContext> options)
            : base(options)
        {
        }

        // DbSets: Mapeiam as Entidades de Domínio para as Tabelas do Banco de Dados
        public DbSet<Product> Products { get; set; }
        public DbSet<Waiter> Waiters { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }

        // Mapeamento e Regras de Relacionamento (Fluent API)
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // 1. Configuração para Herança de Produtos (Table Per Hierarchy - TPH)
            // Mapeia Food e Drink para a tabela Products, usando a coluna 'ProductType'.
            modelBuilder.Entity<Product>()
                .HasDiscriminator<string>("ProductType")
                .HasValue<Food>("Food")
                .HasValue<Drink>("Drink");

            // 2. Relacionamento (Order 1:N OrderItem)
            modelBuilder.Entity<Order>()
                .HasMany(o => o.Items)
                .WithOne(oi => oi.Order)
                .HasForeignKey("OrderId");

            // 3. Relacionamento (Waiter 1:N Order)
            modelBuilder.Entity<Order>()
                .HasOne(o => o.Waiter)
                .WithMany() // Relação 1:N (um Garçom para muitos Pedidos)
                .HasForeignKey(o => o.WaiterId);
        }
    }
}