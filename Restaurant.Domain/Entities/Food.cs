namespace Restaurant.Domain.Entities
{
    public class Food : Product
    {
        public double Weight { get; set; }
        public string Ingredients { get; set; }

        public Food()
        {
            Ingredients = string.Empty;
        }

        // Construtor para Criação (Chama construtor base Product(name, price))
        public Food(string name, double price, double weight, string ingredients)
            : base(name, price)
        {
            Weight = weight;
            Ingredients = ingredients;
        }

        // Construtor Completo com Id (Chama construtor base Product(id, name, price))
        public Food(int id, string name, double price, double weight, string ingredients)
            : base(id, name, price)
        {
            Weight = weight;
            Ingredients = ingredients;
        }
    }
}