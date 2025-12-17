namespace Restaurant.Domain.Entities
{
    public class Drink : Product
    {
        public int Volume { get; set; }

        public Drink()
        {
        }

        // Construtor para Criação
        public Drink(string name, double price, int volume)
            : base(name, price) // Chama o construtor de Product
        {
            Volume = volume;
        }

        // Construtor Completo com Id
        public Drink(int id, string name, double price, int volume)
            : base(id, name, price) // Chama o construtor de Product com Id
        {
            Volume = volume;
        }
    }
}