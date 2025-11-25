using Restaurant.Domain.Entities;
using System;
using System.Collections.Generic;

namespace Restaurant.Domain.Interfaces
{
    // Esta interface define os casos de uso para a entidade Order
    public interface IOrderService
    {
        Order CreateOrder(int tableNumber, int waiterId);
        void AddItemToOrder(int orderId, int productId, int quantity);
        void CloseBill(int orderId);
        double GetTotalRevenue(DateTime date);
        Order GetOrder(int orderId);
        IList<Order> GetOpenOrders();
    }
}