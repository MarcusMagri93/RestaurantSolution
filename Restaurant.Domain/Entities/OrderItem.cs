using Restaurant.Domain.Base;

namespace Restaurant.Domain.Entities
{
    public class OrderItem : BaseEntity<int>
    {
        public int Quantity { get; set; }

        // CHAVES ESTRANGEIRAS EXPLÍCITAS
        public int OrderId { get; set; }
        public int ProductId { get; set; }

        // Propriedades de Navegação
        public Order Order { get; set; } = default!;
        public Product Product { get; set; } = default!;

        public OrderItem() { }

        public OrderItem(int orderId, int productId, int quantity)
        {
            OrderId = orderId;
            ProductId = productId;
            Quantity = quantity;
        }
    }
}