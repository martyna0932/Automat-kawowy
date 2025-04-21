using System.Collections.Generic;
using CoffeeOrderApp.Models;

namespace CoffeeOrderApp.Repositories
{
    public interface IUserRepository
    {
        User GetUserById(int id);
        User GetUserByUsername(string username);
        void UpdateUser(User user);
        List<User> GetAllUsers();
    }
}
