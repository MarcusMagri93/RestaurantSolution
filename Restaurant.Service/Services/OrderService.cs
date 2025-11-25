using AutoMapper;
using Restaurant.Domain.Base;
using Restaurant.Domain.Entities;
using Restaurant.Domain.Interfaces;

using System;
using System.Collections.Generic;
using System.Linq; // Necessário para .Sum() e consultas

namespace Restaurant.Service.Services
{
    // A classe agora herda do BaseService e declara que IMPLEMENTA a interface IOrderService (Corrigindo CS0311)
    public class OrderService : BaseService<Order>, IOrderService
    {
        // O _productRepository deve ser protected na BaseService para ser acessado.
        protected readonly IBaseRepository<Product> _productRepository;

        // Construtor: Recebe TODAS as dependências via Injeção de Dependência
        public OrderService(
            IBaseRepository<Order> baseRepository,
            IBaseRepository<Product> productRepository,
            IMapper mapper)
            : base(baseRepository, mapper) // Chama o construtor da classe base (BaseService)
        {
            // O _baseRepository para Order é herdado, mas o de Product é injetado aqui.
            _productRepository = productRepository;
        }

        // --- Implementação dos Métodos da IOrderService (Casos de Uso) ---

        // Caso de Uso: Registrar Pedido
        public Order CreateOrder(int tableNumber, int waiterId)
        {
            if (tableNumber <= 0 || waiterId <= 0)
                throw new ArgumentException("Dados de Mesa ou Garçom inválidos.");

            var newOrder = new Order(tableNumber, waiterId);

            // Persistência: Usa o repositório de Order herdado
            // Assumimos que o campo '_baseRepository' na classe BaseService é 'protected'.
            base._baseRepository.Insert(newOrder);

            return newOrder;
        }

        // Caso de Uso: Adicionar Item ao Pedido
        public void AddItemToOrder(int orderId, int productId, int quantity)
        {
            var order = base._baseRepository.Select(orderId);
            var product = _productRepository.Select(productId);

            if (order == null) throw new KeyNotFoundException($"Pedido {orderId} não encontrado.");
            if (product == null) throw new KeyNotFoundException($"Produto {productId} não encontrado.");
            if (quantity <= 0) throw new ArgumentException("Quantidade deve ser maior que zero.");

            order.AddItem(product, quantity);
            base._baseRepository.Update(order);
        }

        // Caso de Uso: Fechar Conta
        public void CloseBill(int orderId)
        {
            var order = base._baseRepository.Select(orderId);
            if (order == null) throw new KeyNotFoundException($"Pedido {orderId} não encontrado.");

            order.CloseBill();
            base._baseRepository.Update(order);
        }

        // Caso de Uso: Gerar Relatório Diário
        public double GetTotalRevenue(DateTime date)
        {
            var allOrders = base._baseRepository.Select(tracking: false);
            return allOrders.Sum(o => o.TotalValue);
        }

        // Métodos Auxiliares
        public Order GetOrder(int orderId)
        {
            return base._baseRepository.Select(orderId);
        }

        public IList<Order> GetOpenOrders()
        {
            return base._baseRepository.Select(tracking: false);
        }
    }
}