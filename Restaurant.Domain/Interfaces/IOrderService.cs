using Restaurant.Domain.Entities;
using System.Collections.Generic;
using Restaurant.Domain.Base; // <--- NECESSÁRIO para encontrar IBaseService<Order>

namespace Restaurant.Domain.Interfaces.Base
{
    // CORREÇÃO: IOrderService deve herdar de IBaseService<Order>
    public interface IOrderService : IBaseService<Order>
    {
        // --- Métodos Específicos de Negócio do Pedido ---

        // Métodos de manipulação:
        Order CreateOrder(int tableNumber, int waiterId);
        void AddItemToOrder(int orderId, int productId, int quantity);
        void CloseBill(int orderId);

        // Métodos de consulta:
        Order GetOrder(int orderId);
        double GetTotalRevenue(DateTime date);
        IList<Order> GetOpenOrders();
    }
}