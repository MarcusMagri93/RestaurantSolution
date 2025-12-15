using AutoMapper;
using Restaurant.Domain.Base;
using Restaurant.Domain.Entities;
using Restaurant.Domain.Interfaces.Base;
using Restaurant.Services.Services.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Restaurant.Services.Services
{
    public class OrderService : BaseService<Order>, IOrderService
    {
        protected readonly IBaseRepository<Product> _productRepository;
        protected readonly IBaseRepository<OrderItem> _orderItemRepository;

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

        // Busca histórico completo com detalhes
        public IList<TOutputModel> GetAllWithDetails<TOutputModel>() where TOutputModel : class
        {
            var orders = _repository.Get()
                .Include(o => o.Waiter)
                .Include(o => o.OrderItems)
                .ThenInclude(oi => oi.Product)
                .ToList();

            return _mapper.Map<IList<TOutputModel>>(orders);
        }

        // NOVO: Busca apenas mesas ativas com detalhes
        public IList<TOutputModel> GetOpenOrdersWithDetails<TOutputModel>() where TOutputModel : class
        {
            var orders = _repository.Get()
                .Where(o => !o.IsPaid) // Filtro: Apenas não pagos
                .Include(o => o.Waiter)
                .Include(o => o.OrderItems)
                .ThenInclude(oi => oi.Product)
                .ToList();

            return _mapper.Map<IList<TOutputModel>>(orders);
        }

        public Order CreateOrder(int tableNumber, int waiterId)
        {
            if (tableNumber <= 0 || waiterId <= 0)
                throw new ArgumentException("Dados de Mesa ou Garçom inválidos.");

            var newOrder = new Order()
            {
                TableNumber = tableNumber,
                WaiterId = waiterId,
                TotalAmount = 0,
                OrderItems = new List<OrderItem>()
            };

            _repository.Add(newOrder);
            return newOrder;
        }

        public void AddItemToOrder(int orderId, int productId, int quantity)
        {
            var order = _repository.GetById(orderId);
            var product = _productRepository.GetById(productId);

            if (order == null) throw new KeyNotFoundException($"Pedido {orderId} não encontrado.");
            if (product == null) throw new KeyNotFoundException($"Produto {productId} não encontrado.");
            if (quantity <= 0) throw new ArgumentException("Quantidade deve ser maior que zero.");

            if (order.OrderItems == null) order.OrderItems = new List<OrderItem>();

            var existingItem = order.OrderItems.FirstOrDefault(item => item.ProductId == productId);

            if (existingItem != null)
            {
                existingItem.Quantity += quantity;
                _orderItemRepository.Update(existingItem);
            }
            else
            {
                var newItem = new OrderItem(orderId, productId, quantity);
                _orderItemRepository.Add(newItem);
                order.OrderItems.Add(newItem);
            }

            UpdateOrderTotal(orderId);
            _repository.Update(order);
        }

        public void CloseBill(int orderId)
        {
            var order = _repository.GetById(orderId);
            if (order == null) throw new KeyNotFoundException($"Pedido {orderId} não encontrado.");

            UpdateOrderTotal(orderId);
            order.IsPaid = true;
            _repository.Update(order);
        }

        private void UpdateOrderTotal(int orderId)
        {
            var order = _repository.Get()
                .Include(o => o.OrderItems)
                .FirstOrDefault(o => o.Id == orderId);

            if (order == null) return;

            decimal total = 0;

            foreach (var item in order.OrderItems)
            {
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

        public Order GetOrder(int orderId)
        {
            return _repository.Get()
                .Include(o => o.OrderItems)
                .ThenInclude(i => i.Product)
                .FirstOrDefault(o => o.Id == orderId);
        }

        public double GetTotalRevenue(DateTime date) => (double)_repository.Get().Sum(o => o.TotalAmount);
        public IList<Order> GetOpenOrders() => _repository.Get().Where(o => !o.IsPaid).ToList();
    }
}