using Restaurant.Domain.Base;
using System.Collections.Generic;

namespace Restaurant.Domain.Entities
{
    public class Waiter : BaseEntity<int> 
    {
        public string Name { get; set; } = default!;
        public string Registration { get; set; } = default!; 
        public string Password { get; set; } = default!; 

        public ICollection<Order> Orders { get; set; } = new List<Order>();

        public Waiter()
        {
            Orders = new List<Order>();
        }

        public Waiter(string name, string registration, string password)
        {
            Name = name;
            Registration = registration;
            Password = password; 
            Orders = new List<Order>();
        }
    }
}