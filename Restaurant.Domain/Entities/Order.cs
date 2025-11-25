using Restaurant.Domain.Base;
using System.Collections.Generic;
using System.Linq;

namespace Restaurant.Domain.Entities
{
    public class Order : BaseEntity<int>
    {
        public int TableNumber { get; set; }
        public double TotalValue { get; private set; }

        // Relacionamento com Waiter
        public int WaiterId { get; set; } // Chave Estrangeira
        public Waiter Waiter { get; set; } = default!; // Propriedade de Navegação

        // Relacionamento com OrderItem (Coleção)
        private List<OrderItem> _items;
        public IReadOnlyList<OrderItem> Items => _items.AsReadOnly();

        // Construtor Vazio (Padrão do Professor)
        public Order()
        {
            _items = new List<OrderItem>();
        }

        // Construtor para Criação (Recebe WaiterId)
        public Order(int tableNumber, int waiterId)
        {
            TableNumber = tableNumber;
            WaiterId = waiterId;
            _items = new List<OrderItem>();
            CalculateTotal();
        }

        // Construtor Completo com Id (para Carregamento)
        public Order(int id, int tableNumber, double totalValue, int waiterId) : base(id)
        {
            TableNumber = tableNumber;
            TotalValue = totalValue;
            WaiterId = waiterId;
            _items = new List<OrderItem>();
        }

        // Método do Diagrama de Classe: Adiciona um item (Lógica de Domínio)
        public void AddItem(Product product, int quantity)
        {
            var newItem = new OrderItem(product, quantity);
            _items.Add(newItem);
            CalculateTotal();
        }

        private void CalculateTotal()
        {
            TotalValue = _items.Sum(item => item.CalculateSubtotal());
        }

        // Método do Diagrama de Classe: Fechar Conta
        public void CloseBill()
        {
            CalculateTotal();
            // Em um projeto real, você mudaria o status do pedido aqui.
        }
    }
}