using Restaurant.Domain.Base;

namespace Restaurant.Domain.Entities
{
    public abstract class Product : BaseEntity<int>
    {
        public string Name { get; set; } = default!;
        public double Price { get; set; }

        public Product()
        {
            Name = string.Empty;
        }

        protected Product(string name, double price)
        {
            Name = name;
            Price = price;
        }

        // Construtor completo para herança
        protected Product(int id, string name, double price) : base(id)
        {
            Name = name;
            Price = price;
        }
    }
}