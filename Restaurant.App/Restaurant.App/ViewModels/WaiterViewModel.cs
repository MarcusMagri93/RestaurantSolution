using System.Collections.Generic;
using Restaurant.Domain.Entities;

namespace Restaurant.App.ViewModel
{
    public class WaiterViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;

        public string Registration { get; set; } = default!;

        public string Password { get; set; } = default!;
        public ICollection<Order> Orders { get; set; } = new List<Order>();
    }
}