using Restaurant.Domain.Base;
using System.Collections.Generic;

namespace Restaurant.Domain.Entities
{
    public class Order : BaseEntity<int>
    {
        public decimal TotalAmount { get; set; }
        public bool IsPaid { get; set; }
        public int TableNumber { get; set; }
        public double TotalValue { get; set; } // Set é público, a lógica está no Service.

        // Chaves Estrangeiras
        public int WaiterId { get; set; }

        // Navegação (N:1)
        public Waiter Waiter { get; set; } = default!;

        // CORREÇÃO: Coleção pública (1:N)
        public ICollection<OrderItem> OrderItems { get; set; }

        public Order()
        {
            OrderItems = new List<OrderItem>();
        }

        // Construtor alinhado com o padrão de dados
        public Order(int tableNumber, double totalValue, int waiterId)
        {
            TableNumber = tableNumber;
            TotalValue = totalValue;
            WaiterId = waiterId;
            OrderItems = new List<OrderItem>();
        }
    }
}