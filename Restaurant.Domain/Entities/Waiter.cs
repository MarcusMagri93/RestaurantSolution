using Restaurant.Domain.Base;
using System.Collections.Generic;

namespace Restaurant.Domain.Entities
{
    public class Waiter : BaseEntity<int>
    {
        public string Name { get; set; } = default!;
        public string Registration { get; set; } = default!; // Matrícula ou código de acesso
        public string Password { get; set; } = default!; // Propriedade já inicializada

        public ICollection<Order> Orders { get; set; }

        public Waiter()
        {
            Orders = new List<Order>();
        }

        // CONSTRUTOR CORRIGIDO: Adiciona o parâmetro 'password' e o inicializa
        public Waiter(string name, string registration, string password)
        {
            Name = name;
            Registration = registration;
            Password = password; 
            Orders = new List<Order>();
        }
    }
}