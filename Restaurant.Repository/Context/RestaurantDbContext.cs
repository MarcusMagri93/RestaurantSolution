using Microsoft.EntityFrameworkCore;
using Restaurant.Domain.Entities;
using System.Reflection; // Necessário para ApplyConfigurationsFromAssembly

namespace Restaurant.Repository.Context
{
    public class RestaurantDbContext : DbContext
    {
        // Construtor Vazio (Necessário para a Migração)
        public RestaurantDbContext()
        {
        }

        public RestaurantDbContext(DbContextOptions<RestaurantDbContext> options)
            : base(options)
        {
        }

        // DbSets
        public DbSet<Product> Products { get; set; }
        public DbSet<Waiter> Waiters { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                // Configuração MySQL usando a biblioteca Pomelo ou MySql.EntityFrameworkCore
                const string connectionString = "server=localhost;port=3306;database=RestaurantDB;user=root;password="; // Senha vazia

                // Opção 1: Se estiver usando Pomelo
                optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));

            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // CORREÇÃO: Aplica TODOS os mapeamentos da pasta Mapping de uma só vez (Padrão PetShop)
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            modelBuilder.Entity<Waiter>()
        .Property(w => w.Id)
        .ValueGeneratedOnAdd(); // Diz ao EF Core que o ID é gerado pelo banco (auto-increment)

            // 2. CONFIGURAÇÃO DE CAMPOS OBRIGATÓRIOS
            modelBuilder.Entity<Waiter>()
                .Property(w => w.Name).IsRequired().HasMaxLength(100);

            modelBuilder.Entity<Waiter>()
                .Property(w => w.Registration).IsRequired().HasMaxLength(50);

            modelBuilder.Entity<Waiter>()
                .Property(w => w.Password).IsRequired().HasMaxLength(50);

            // 3. RELAÇÃO (Para evitar erros futuros se a tabela Orders estiver faltando)
            modelBuilder.Entity<Waiter>()
                .HasMany(w => w.Orders)
                .WithOne(o => o.Waiter)
                .HasForeignKey(o => o.WaiterId);

        }
    }
}