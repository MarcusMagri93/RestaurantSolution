using Restaurant.Domain.Entities; 

namespace Restaurant.App.ViewModel
{
    public class OrderItemViewModel
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal Subtotal { get; set; }

        public Product Product { get; set; } 
    }
}