using FlowerShop.Data;
using FlowerShop.Models;
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
        public void ChangePassword(string username, string password)
        {
            try
            {
                User user = GetUserByUsername(username);
                if (user == null)
                {
                    throw new ArgumentException("Invalid username!");
                }
                user.Password = password;
                context.Users.Update(user);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void ChangeUsername(string username)
        {
            //doesn't work like intended
            try
            {
                User user = GetUserByUsername(username);
                if (username != null)
                {
                    throw new ArgumentException("User already exists!");
                }
                user.Username = username;
                context.Update(user);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public void AddBalance(string username, string balance)
        {
            try
            {
                User user = GetUserByUsername(username);
                if (double.Parse(balance) <= 0 || user == null)
                {
                    //!double.TryParse(balance, out _) -> check if this is needed
                    throw new ArgumentException("Invalid data!");
                }
                user.Balance += double.Parse(balance);
                context.Users.Update(user);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void CreateUser(string username, string password, string balance)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(username) ||
                string.IsNullOrWhiteSpace(password) ||
                string.IsNullOrWhiteSpace(balance))
                {
                    throw new ArgumentException("Invalid user data!");
                }

                double initialBalance = double.Parse(balance);
                if (GetUserByUsername(username) != null)
                {
                    throw new ArgumentException("User already exists!");
                }
                if (password.Length < 4)
                {
                    throw new ArgumentException("Password is too short!");
                }
                if (initialBalance < 0)
                {
                    throw new ArgumentException("Invalid balance!");
                }

                User user = new User()
                {
                    Username = username,
                    Password = password,
                    Balance = initialBalance,
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

        public ICollection<string> GetAllUsersUsernames()
        {
            return this.context.Users
                .OrderBy(x => x.Username)
                .Select(x => x.Username)
                .ToList();
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
