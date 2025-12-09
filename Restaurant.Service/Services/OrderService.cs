using AutoMapper;
using Restaurant.Domain.Base;
using Restaurant.Domain.Entities;
using Restaurant.Domain.Interfaces;
using Restaurant.Domain.Interfaces.Base;
using Restaurant.Domain.Base; 
using Restaurant.Services.Services.Base; 
using System;
using System.Collections.Generic;
using System.Linq;

namespace Restaurant.Services.Services
{
    public class OrderService : BaseService<Order>, IOrderService
    {
        // Repositórios necessários. IBaseRepository injeta o repositório genérico.
        protected readonly IBaseRepository<Product> _productRepository;
        protected readonly IBaseRepository<OrderItem> _orderItemRepository;

        public OrderService(
            // O primeiro parâmetro deve ser IBaseRepository<Order> para o BaseService
            IBaseRepository<Order> baseRepository,
            IBaseRepository<Product> productRepository,
            IBaseRepository<OrderItem> orderItemRepository,
            IMapper mapper)
            : base(baseRepository, mapper) // Chamada correta ao construtor da classe base
        {
            _productRepository = productRepository;
            _orderItemRepository = orderItemRepository;
        }

        // --- Implementação dos Métodos da IOrderService ---

        public Order CreateOrder(int tableNumber, int waiterId)
        {
            if (tableNumber <= 0 || waiterId <= 0)
                throw new ArgumentException("Dados de Mesa ou Garçom inválidos.");

            var newOrder = new Order()
            {
                TableNumber = tableNumber,
                WaiterId = waiterId,
                TotalAmount = 0, // CORRIGIDO: Usando TotalAmount
                OrderItems = new List<OrderItem>()
            };

            // CORRIGIDO: Usando _repository (campo da classe base) e método Add
            _repository.Add(newOrder);

            // Nota: Se você estiver usando IUnitOfWork, o commit será feito fora deste serviço.
            return newOrder;
        }

        public void AddItemToOrder(int orderId, int productId, int quantity)
        {
            // CORRIGIDO: Usando _repository e método GetById
            var order = _repository.GetById(orderId);
            var product = _productRepository.GetById(productId); // CORRIGIDO: Usando GetById

            if (order == null) throw new KeyNotFoundException($"Pedido {orderId} não encontrado.");
            if (product == null) throw new KeyNotFoundException($"Produto {productId} não encontrado.");
            if (quantity <= 0) throw new ArgumentException("Quantidade deve ser maior que zero.");

            var existingItem = order.OrderItems.FirstOrDefault(item => item.ProductId == productId);

            if (existingItem != null)
            {
                existingItem.Quantity += quantity;
                _orderItemRepository.Update(existingItem);
            }
            else
            {
                // Este construtor pode falhar se OrderItem não tiver construtor que receba 3 ints
                var newItem = new OrderItem(orderId, productId, quantity);
                _orderItemRepository.Add(newItem); // CORRIGIDO: Usando Add

                order.OrderItems.Add(newItem);
            }

            UpdateOrderTotal(orderId);
            // Salva o Order modificado
            _repository.Update(order);
        }

        public void CloseBill(int orderId)
        {
            var order = _repository.GetById(orderId); // CORRIGIDO: Usando GetById
            if (order == null) throw new KeyNotFoundException($"Pedido {orderId} não encontrado.");

            UpdateOrderTotal(orderId);
            order.IsPaid = true; // Assumindo que você tem IsPaid na entidade Order.
            _repository.Update(order);
        }

        private void UpdateOrderTotal(int orderId)
        {
            // O serviço precisa carregar a lista de itens relacionados
            // Nota: Esta lógica deve ser refinada para usar includes no repositório.
            var order = _repository.Get().FirstOrDefault(o => o.Id == orderId);

            if (order == null) return;

            // CORRIGIDO: Inicializando como decimal
            decimal total = 0;

            // Recalcula o total (requer carregar o preço do produto)
            foreach (var item in order.OrderItems)
            {
                // CORRIGIDO: O repositório deve ser GetById, não Select
                var product = _productRepository.GetById(item.ProductId);

                if (product != null)
                {
                    
                    decimal itemPrice = Convert.ToDecimal(product.Price);

                    
                    total += item.Quantity * itemPrice;
                }
            }

            
            order.TotalAmount = total;

            _repository.Update(order);
        }

        // Outros métodos
        public Order GetOrder(int orderId) => _repository.GetById(orderId); // CORRIGIDO: Usando GetById
        public double GetTotalRevenue(DateTime date) => (double)_repository.Get().Sum(o => o.TotalAmount);
        public IList<Order> GetOpenOrders() => _repository.Get().Where(o => !o.IsPaid).ToList(); // Adicionei filtro
    }
}