using System.Collections.Generic;
using CoffeeOrderApp.Models;

namespace CoffeeOrderApp.Repositories
{
    public interface IOrderRepository
    {
        void AddOrder(Order order);
        List<Order> GetOrdersByUserId(int userId);
        List<Order> GetAllOrders();

    }
}
