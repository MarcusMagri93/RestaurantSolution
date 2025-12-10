using Microsoft.EntityFrameworkCore;
using Restaurant.Domain.Entities;
using Restaurant.Repository.Mapping;
using System.Reflection; // Necessário para ApplyConfigurationsFromAssembly

namespace Restaurant.Repository.Context
{
    public class RestaurantDbContext : DbContext
    {
        public RestaurantDbContext(DbContextOptions<RestaurantDbContext>? options = null) :
           base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL("server=localhost;port=3306;database=RestaurantDB;user=root;password=");
        }
        public DbSet<Drink> Drink { get; set; }
        public DbSet<Food> Food { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<OrderItem> OrderItem { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<Waiter> Waiter { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Drink>(new DrinkMap().Configure);
            modelBuilder.Entity<Food>(new FoodMap().Configure);
            modelBuilder.Entity<OrderItem>(new OrderItemMap().Configure);
            modelBuilder.Entity<Order>(new OrderMap().Configure);
            modelBuilder.Entity<Product>(new ProductMap().Configure);
            modelBuilder.Entity<Waiter>(new WaiterMap().Configure);

        }
    }
}