using Microsoft.EntityFrameworkCore;
using CoffeeOrderApp.Models;
using System;

namespace CoffeeOrderApp.Models
{
    public class CoffeeDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Order> Orders { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=coffee.db");
        }
    }
}
