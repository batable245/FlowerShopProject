using FlowerShop.Data;
using FlowerShop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowerShop.Services
{
    public class UserService : IUserService
    {
        private readonly AppDbContext context;

        public UserService()
        {
            context = new AppDbContext();
        }
        public void ChangePassword(string password)
        {
            throw new NotImplementedException();
        }

        public void ChangeUsername(string username)
        {
            throw new NotImplementedException();
        }

        public void CreateUser(string username, string password)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(username) ||
                string.IsNullOrWhiteSpace(password))
                {
                    throw new ArgumentException("Invalid user data!");
                }

                User userValidation = context.Users.Where(u => u.Username == username).FirstOrDefault();

                if (userValidation != null)
                {
                    throw new ArgumentException("User already exists!");
                }
                if (password.Length < 4)
                {
                    throw new ArgumentException("Password is too short!");
                }

                User user = new User()
                {
                    Username = username,
                    Password = password,
                    Role = Role.USER,
                    RegisterDate = DateTime.Now,
                };
                context.Users.Add(user);
                context.SaveChanges();
                Console.WriteLine("User created!");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void DeleteUserById(int id)
        {
            try
            {
                User user = GetUserById(id);
                if (user == null)
                {
                    throw new ArgumentException("User not found!");
                }
                context.Users.Remove(user);
                context.SaveChanges();
                Console.WriteLine("User removed!");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void DeleteUserByUsername(string username)
        {
            throw new NotImplementedException();
        }

        public ICollection<string> GetAllUsers()
        {
            throw new NotImplementedException();
        }

        public User GetUserById(int id)
        {
            return this.context.Users.Find(id);
        }

        public User GetUserByUsername(string username)
        {
            User user = this.context.Users.Where(x => x.Username == username).FirstOrDefault();
            return user;
        }

        public bool LogIn(string username, string password)
        {
            throw new NotImplementedException();
        }

        public void SignOut()
        {
            throw new NotImplementedException();
        }
    }
}
