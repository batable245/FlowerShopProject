using FlowerShop.Data.Models;
using System.Collections.Generic;

namespace FlowerShop.Services
{
    public interface IUserService
    {
        public void CreateUser(string username, string password);
        public void DeleteUserByUsername(string username);
        public void ChangeUsername(string username);
        public void ChangePassword(string password);
        public void DeleteUserById(int id);
        public ICollection<string> GetAllUsers();
        public bool LogIn(string username, string password);
        public void SignOut();
        public User GetUserById(int id);
        public User GetUserByUsername(string username);
    }
}
