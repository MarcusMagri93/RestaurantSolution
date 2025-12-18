namespace Restaurant.Domain.Entities
{
    public class Drink : Product
    {
        public int Volume { get; set; }

        // CONSTRUTOR VAZIO -> EntiTy Framework "materialar" os dados vindos do banco
        public Drink()
        {
        }

        //  CONSTRUTOR 
        public Drink(string name, double price, int volume)
            : base(name, price)
        {
            Volume = volume;
        }

        // CONSTRUTOR COMPLETO COM ID
        public Drink(int id, string name, double price, int volume)
            : base(id, name, price)
        {
            Volume = volume;
        }
    }
}