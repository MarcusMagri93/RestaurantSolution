using Restaurant.Domain.Base;

namespace Restaurant.Domain.Entities
{
    // A classe é abstrata para que ninguém possa criar um "Product" genérico.
    // Herda de BaseEntity<int>
    public abstract class Product : BaseEntity<int>
    {
        // Propriedades com o padrão de get/set do professor (com ? para tipos de referência se aplicável)
        public string Name { get; set; }
        public double Price { get; set; }

        // Construtor Vazio (Necessário para o Entity Framework e o padrão do professor)
        public Product()
        {
            Name  = string.Empty;
        }

        // Construtor para Criação de um Novo Produto
        protected Product(string name, double price)
        {
            Name = name;
            Price = price;
        }

        // Construtor Completo com Id (para Carregamento do Banco de Dados)
        // Chama o construtor BaseEntity(id)
        protected Product(int id, string name, double price) : base(id)
        {
            Name = name;
            Price = price;
        }

        // Polimorfismo: Método virtual para cálculo de preço
        public virtual double CalculatePrice()
        {
            return Price;
        }
    }
}