using Restaurant.Domain.Entities;
using System.Collections.Generic;
using Restaurant.Domain.Base;
using System;

namespace Restaurant.Domain.Interfaces.Base // Namespace ajustado conforme o original
{
    public interface IOrderService : IBaseService<Order>
    {
        Order CreateOrder(int tableNumber, int waiterId);
        void AddItemToOrder(int orderId, int productId, int quantity);
        void CloseBill(int orderId);

        Order GetOrder(int orderId);
        double GetTotalRevenue(DateTime date);
        IList<Order> GetOpenOrders();

        // Melhoria Etapa 2: Método para buscar pedidos com detalhes carregados
        IList<TOutputModel> GetAllWithDetails<TOutputModel>() where TOutputModel : class;
    }
}