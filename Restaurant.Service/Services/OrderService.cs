using AutoMapper;
using Restaurant.Domain.Base;
using Restaurant.Domain.Entities;
using Restaurant.Domain.Interfaces.Base;
using Restaurant.Services.Services.Base;
using Microsoft.EntityFrameworkCore;

namespace Restaurant.Services.Services
{
    public class OrderService : BaseService<Order>, IOrderService
    {
        // Repositórios auxiliares 
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

        // Consulta Detalhada
        public IList<TOutputModel> GetAllWithDetails<TOutputModel>() where TOutputModel : class
        {
            var orders = _repository.Get()
                .Include(o => o.Waiter)
                .Include(o => o.OrderItems)
                .ThenInclude(oi => oi.Product)
                .ToList();

            return _mapper.Map<IList<TOutputModel>>(orders);
        }

        public IList<TOutputModel> GetOpenOrdersWithDetails<TOutputModel>() where TOutputModel : class
        {
            var orders = _repository.Get()
                .Where(o => !o.IsPaid) // Filtra apenas o que ainda não foi faturado
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

            // Se o item já existe no pedido, apenas soma a quantidade
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

            // Atualiza o total do pedido sempre que um item é mexido
            order.TotalAmount = CalcularTotalLocal(order);
            _repository.Update(order);
        }

        public void CloseBill(int orderId)
        {
            var order = _repository.Get()
                .Include(o => o.OrderItems)
                .FirstOrDefault(o => o.Id == orderId);

            if (order == null) throw new KeyNotFoundException($"Pedido {orderId} não encontrado.");

            // Calcula o total final e marca a mesa como livre (IsPaid = true)
            order.TotalAmount = CalcularTotalLocal(order);
            order.IsPaid = true;

            _repository.Update(order);
        }

        // Cálculo da conta
        private decimal CalcularTotalLocal(Order order)
        {
            decimal total = 0;
            if (order.OrderItems == null) return 0;

            foreach (var item in order.OrderItems)
            {
                var product = _productRepository.GetById(item.ProductId);
                if (product != null)
                {
                    total += item.Quantity * (decimal)product.Price;
                }
            }
            return total;
        }

        public Order GetOrder(int orderId)
        {
            return _repository.Get()
                .Include(o => o.OrderItems)
                .ThenInclude(i => i.Product)
                .FirstOrDefault(o => o.Id == orderId);
        }

        public double GetTotalRevenue(DateTime date)
        {
            // Lógica de fechamento de caixa diário
            var inicioDia = date.Date;
            var fimDia = inicioDia.AddDays(1);

            return (double)_repository.Get()
                .Where(o => o.IsPaid && o.OrderDate >= inicioDia && o.OrderDate < fimDia)
                .Sum(o => o.TotalAmount);
        }

        public IList<Order> GetOpenOrders() => _repository.Get().Where(o => !o.IsPaid).ToList();
    }
}