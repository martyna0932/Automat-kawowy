using System.Collections.Generic;
using System.Linq;
using CoffeeOrderApp.Models;


namespace CoffeeOrderApp.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly CoffeeDbContext _context;

        public OrderRepository(CoffeeDbContext context)
        {
            _context = context;
        }

        public void AddOrder(Order order)
        {
            _context.Orders.Add(order);
            _context.SaveChanges();
        }

        public List<Order> GetOrdersByUserId(int userId)
        {
            return _context.Orders.Where(o => o.UserId == userId).ToList();
        }
    }
}
