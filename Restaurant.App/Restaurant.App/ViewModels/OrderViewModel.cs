using Restaurant.Domain.Entities; // Necessário para referenciar OrderItem e Waiter

namespace Restaurant.App.ViewModel
{
    public class OrderViewModel
    {
        public int Id { get; set; }
        public int TableNumber { get; set; }
        public int WaiterId { get; set; }
        public decimal TotalAmount { get; set; }
        public bool IsPaid { get; set; }

        // Propriedades de navegação (seguindo o padrão BookViewModel de usar a Entidade)
        public Waiter Waiter { get; set; } = new Waiter();
        public List<OrderItem> OrderItems { get; set; } = [];
    }
}