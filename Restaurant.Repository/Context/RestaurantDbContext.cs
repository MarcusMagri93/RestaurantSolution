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

                // Opção 2: Se estiver usando MySql.EntityFrameworkCore (usado anteriormente)
                // optionsBuilder.UseMySQL(connectionString); 
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // CORREÇÃO: Aplica TODOS os mapeamentos da pasta Mapping de uma só vez (Padrão PetShop)
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            // OBS: O TPH (Herança de Produtos) já está no ProductMap.cs e será aplicado automaticamente.
        }
    }
}