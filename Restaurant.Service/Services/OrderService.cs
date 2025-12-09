using AutoMapper;
using Restaurant.Domain.Base;
using Restaurant.Domain.Entities;
using Restaurant.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Restaurant.Services.Services
{
    public class OrderService : BaseService<Order>, IOrderService
    {
        protected readonly IBaseRepository<Product> _productRepository;
        protected readonly IBaseRepository<OrderItem> _orderItemRepository; // Novo Repositório

        public OrderService(
            IBaseRepository<Order> baseRepository,
            IBaseRepository<Product> productRepository,
            IBaseRepository<OrderItem> orderItemRepository,
            IMapper mapper)
            : base(baseRepository, mapper)
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
                TotalValue = 0,
                OrderItems = new List<OrderItem>()
            };

            base._baseRepository.Insert(newOrder);
            return newOrder;
        }

        public void AddItemToOrder(int orderId, int productId, int quantity)
        {
            var order = base._baseRepository.Select(orderId);
            var product = _productRepository.Select(productId);

            if (order == null) throw new KeyNotFoundException($"Pedido {orderId} não encontrado.");
            if (product == null) throw new KeyNotFoundException($"Produto {productId} não encontrado.");
            if (quantity <= 0) throw new ArgumentException("Quantidade deve ser maior que zero.");

            // Lógica de Domínio (usando a coleção OrderItems pública)
            var existingItem = order.OrderItems.FirstOrDefault(item => item.ProductId == productId);

            if (existingItem != null)
            {
                existingItem.Quantity += quantity;
                _orderItemRepository.Update(existingItem);
            }
            else
            {
                // Note: O construtor OrderItem agora requer OrderId, ProductId e Quantity
                var newItem = new OrderItem(orderId, productId, quantity);
                _orderItemRepository.Insert(newItem);

                // Força o Order a ter a coleção completa para o Total ser correto
                order.OrderItems.Add(newItem);
            }

            UpdateOrderTotal(orderId);
        }

        public void CloseBill(int orderId)
        {
            var order = base._baseRepository.Select(orderId);
            if (order == null) throw new KeyNotFoundException($"Pedido {orderId} não encontrado.");

            UpdateOrderTotal(orderId);
            // Lógica de fechamento (ex: muda status)
            // ...
            base._baseRepository.Update(order);
        }

        private void UpdateOrderTotal(int orderId)
        {
            // O serviço precisa carregar a lista de itens relacionados
            var order = base._baseRepository.Select(orderId, tracking: true, includes: new List<string> { nameof(Order.OrderItems) });

            if (order == null) return;

            // Recalcula o total (requer carregar o preço do produto)
            double total = 0;
            foreach (var item in order.OrderItems)
            {
                var product = _productRepository.Select(item.ProductId);
                if (product != null)
                {
                    total += item.Quantity * product.Price;
                }
            }

            order.TotalValue = total;
            base._baseRepository.Update(order);
        }

        // Outros métodos
        public Order GetOrder(int orderId) => base._baseRepository.Select(orderId, tracking: false, includes: new List<string> { nameof(Order.OrderItems) });
        public double GetTotalRevenue(DateTime date) => base._baseRepository.Select(tracking: false).Sum(o => o.TotalValue);
        public IList<Order> GetOpenOrders() => base._baseRepository.Select(tracking: false);
    }
}