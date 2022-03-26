using FlowerShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlowerShop.Data;

namespace DataProcessor
{
    public class DataSeeder
    {
        private readonly AppDbContext context;


        public DataSeeder()
        {
            this.context = new AppDbContext();
        }

        public void Run()
        {
            SeedUsers();
            SeedFlowers();
        }

        private void SeedUsers()
        {
            List<User> users = new List<User>();

            users.Add(new User() { Username = "admin", Password = "admin", Balance = 50000, RegisterDate = DateTime.Now });
            users.Add(new User() { Username = "Manolo", Password = "Manolo21", Balance = 50, RegisterDate = DateTime.Now });
            users.Add(new User() { Username = "Hadewig", Password = "Hadewig07", Balance = 27, RegisterDate = DateTime.Now });
            users.Add(new User() { Username = "Hristofor", Password = "123345", Balance = 36, RegisterDate = DateTime.Now });
            users.Add(new User() { Username = "Ralphine", Password = "HappyCow", Balance = 48, RegisterDate = DateTime.Now });
            users.Add(new User() { Username = "Sabella", Password = "HappyDays1", Balance = 100, RegisterDate = DateTime.Now });
            users.Add(new User() { Username = "Wade", Password = "Jacks0n", Balance = 0, RegisterDate = DateTime.Now });
            users.Add(new User() { Username = "Jackson", Password = "242526", Balance = 10, RegisterDate = DateTime.Now });
            users.Add(new User() { Username = "Merlin", Password = "Monro", Balance = 68, RegisterDate = DateTime.Now });
            users.Add(new User() { Username = "Kendall", Password = "Vedball", Balance = 73, RegisterDate = DateTime.Now });
            users.Add(new User() { Username = "Vickie", Password = "Viking", Balance = 84, RegisterDate = DateTime.Now });
            users.Add(new User() { Username = "Jeanette", Password = "Scarlett", Balance = 17, RegisterDate = DateTime.Now });
            users.Add(new User() { Username = "Nikkole", Password = "Niki04", Balance = 23, RegisterDate = DateTime.Now });
            users.Add(new User() { Username = "Stirling", Password = "Speedo", Balance = 96, RegisterDate = DateTime.Now });
            users.Add(new User() { Username = "Raffael", Password = "Champi0n", Balance = 8, RegisterDate = DateTime.Now });
            users.Add(new User() { Username = "Debi", Password = "Debito88", Balance = 43, RegisterDate = DateTime.Now });

            context.Users.AddRange(users);
            context.SaveChanges();
        }

        private void SeedFlowers()
        {
            List<Flower> flowers = new List<Flower>();

            flowers.Add(new Flower() { Name = "Rose", Price = 5, Quantity = 28 });
            flowers.Add(new Flower() { Name = "Tulip", Price = 3, Quantity = 32 });
            flowers.Add(new Flower() { Name = "Lilly", Price = 5, Quantity = 8 });
            flowers.Add(new Flower() { Name = "Jasmine", Price = 3, Quantity = 71 });
            flowers.Add(new Flower() { Name = "Marigold", Price = 4, Quantity = 34 });
            flowers.Add(new Flower() { Name = "Lotus", Price = 15, Quantity = 12 });
            flowers.Add(new Flower() { Name = "Orchid", Price = 8, Quantity = 14 });
            flowers.Add(new Flower() { Name = "Waterlilly", Price = 10, Quantity = 23 });
            flowers.Add(new Flower() { Name = "Buttercups", Price = 1.5, Quantity = 43 });
            flowers.Add(new Flower() { Name = "Calendula", Price = 1, Quantity = 73 });
            flowers.Add(new Flower() { Name = "Geranium", Price = 6, Quantity = 15 });
            flowers.Add(new Flower() { Name = "Daisy", Price = 2, Quantity = 100 });
            flowers.Add(new Flower() { Name = "Lavender", Price = 4, Quantity = 17 });
            flowers.Add(new Flower() { Name = "Snowdrop", Price = 2.5, Quantity = 65 });
            flowers.Add(new Flower() { Name = "Daffodil", Price = 2, Quantity = 38 });
            flowers.Add(new Flower() { Name = "Cowslip", Price = 1, Quantity = 50 });

            context.Flowers.AddRange(flowers);
            context.SaveChanges();
        }
    }
}
