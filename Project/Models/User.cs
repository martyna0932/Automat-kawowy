﻿using System;

namespace CoffeeOrderApp.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Password { get; set; }
        public string UserName { get; set; }
        public string Role { get; set; }
        public int LoyaltyPoints { get; set; }
    }
}
