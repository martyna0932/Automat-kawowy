using System;

namespace CoffeeOrderApp.Models
{
    public class Order
    {
        public int Id { get; set; }
        public string Coffee { get; set; }
        public string Milk { get; set; }
        public string Syrup { get; set; }
        public decimal Price { get; set; }
        public DateTime OrderDate { get; set; }
        public int UserId { get; set; }
    }
}
