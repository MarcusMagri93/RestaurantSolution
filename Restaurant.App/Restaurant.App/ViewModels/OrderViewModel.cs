using Restaurant.Domain.Entities;
using System.Collections.Generic;

namespace Restaurant.App.ViewModel
{
    public class OrderViewModel
    {
        public int Id { get; set; }
        public int TableNumber { get; set; }
        public int WaiterId { get; set; }
        public decimal TotalAmount { get; set; }
        public bool IsPaid { get; set; }
        public string ProductsSummary { get; set; } = string.Empty;

        public Waiter Waiter { get; set; } = new Waiter();
        public List<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
    }
}