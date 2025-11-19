namespace Restaurant.Domain.Entities
{
    public class Food : Product
    {
        public double Weight { get; set; }
        public string Ingredients { get; set; }

        // Construtor Vazio (Padrão do Professor)
        public Food()
        {
            Ingredients = string.Empty;
        }

        // Construtor para Criação
        public Food(string name, double price, double weight, string ingredients)
            : base(name, price) // Chama o construtor de Product
        {
            Weight = weight;
            Ingredients = ingredients;
        }

        // Construtor Completo com Id
        public Food(int id, string name, double price, double weight, string ingredients)
            : base(id, name, price) // Chama o construtor de Product com Id
        {
            Weight = weight;
            Ingredients = ingredients;
        }
    }
}