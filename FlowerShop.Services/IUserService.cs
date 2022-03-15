using FlowerShop.Models;
using System.Collections.Generic;

namespace FlowerShop.Services
{
    public interface IUserService
    {
        public void CreateUser(string username, string password, string balance);
        public void DeleteUserByUsername(string username);
        public void ChangeUsername(string currentUsername, string newUsername);
        public void ChangePassword(string username, string password);
        public void DeleteUserById(int id);
        public void AddBalance(string username, string balance);
        public ICollection<string> GetAllUsersUsernames();
        public bool LogIn(string username, string password);
        public User GetUserById(int id);
        public User GetUserByUsername(string username);
    }
}