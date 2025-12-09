using Restaurant.Domain.Entities; // Necessário para referenciar a Entidade Product

namespace Restaurant.App.ViewModel
{
    public class OrderItemViewModel
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal Subtotal { get; set; }

        // Propriedade de navegação (seguindo o padrão BookViewModel de usar a Entidade)
        public Product Product { get; set; } 
    }
}