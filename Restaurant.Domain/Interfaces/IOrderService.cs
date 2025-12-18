using Restaurant.Domain.Entities;
using System.Collections.Generic;
using Restaurant.Domain.Base;
using System;

namespace Restaurant.Domain.Interfaces.Base
{
    public interface IOrderService : IBaseService<Order>
    {
        Order CreateOrder(int tableNumber, int waiterId);
        void AddItemToOrder(int orderId, int productId, int quantity);
        void CloseBill(int orderId);

        Order GetOrder(int orderId);
        double GetTotalRevenue(DateTime date);
        IList<Order> GetOpenOrders();

        // Busca Todos os pedidos 
        IList<TOutputModel> GetAllWithDetails<TOutputModel>() where TOutputModel : class;

        // Busca apenas os pedidos em aberto 
        IList<TOutputModel> GetOpenOrdersWithDetails<TOutputModel>() where TOutputModel : class;
    }
}