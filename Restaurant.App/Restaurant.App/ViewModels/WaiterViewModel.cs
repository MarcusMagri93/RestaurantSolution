using System.Collections.Generic;
using Restaurant.Domain.Entities;

namespace Restaurant.App.ViewModel
{
    public class WaiterViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;

        // ESSENCIAL PARA O LOGIN: A propriedade 'Registration'
        public string Registration { get; set; } = default!;

        // ESSENCIAL PARA O LOGIN: A ViewModel precisa da senha para comparação
        public string Password { get; set; } = default!;

        // Relação de Navegação (opcional, mas bom para o mapeamento)
        public ICollection<Order> Orders { get; set; } = new List<Order>();
    }
}