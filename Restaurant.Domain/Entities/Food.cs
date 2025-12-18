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

        public Food(string name, double price, double weight, string ingredients)
            : base(name, price)
        {
            Weight = weight;
            Ingredients = ingredients;
        }

        public Food(int id, string name, double price, double weight, string ingredients)
            : base(id, name, price)
        {
            Weight = weight;
            Ingredients = ingredients;
        }
    }
}