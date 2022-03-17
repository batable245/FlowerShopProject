using FlowerShop.Data;
using FlowerShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowerShop.Services
{
    public class SaleService : ISaleService
    {
        private readonly AppDbContext context;
        private readonly FlowerService flowerService;
        private readonly UserService userService;
        public SaleService(AppDbContext context, FlowerService flowerService, UserService userService)
        {
            this.context = context;
            this.flowerService = flowerService;
            this.userService = userService;
        }
       
        public void BuyFlower(string flowerName, int quantity, string username)
        {
            Flower flower = flowerService.GetFlowerByName(flowerName);
            User user = userService.GetUserByUsername(username);
            if (flowerName == null)
            {
                throw new ArgumentException("Flower not found!");
            }
            if (username == null)
            {
                throw new ArgumentException("User not found!");
            }
            if (user.Balance < flower.Price * quantity)
            {
                throw new ArgumentException("Insufficient balance!");
            }
            if (flower.Quantity < quantity)
            {
                throw new ArgumentException("Not enought flowers!");
            }
            FlowerSale flowerSale = new FlowerSale();
            flowerSale.Flower = flower;
            flowerSale.User = user;
            flowerSale.Quantity = quantity;
            flowerSale.Date = DateTime.UtcNow;
            flowerSale.Price = flower.Price;

            user.Balance -= flower.Price * quantity;
            flower.Quantity -= quantity;
            context.Update(flower);
            context.Update(user);
            context.Add(flowerSale);
            context.SaveChanges();
        }

        public List<FlowerSale> GetPurchasedFlowersByUser(string username)
        {
            User user = userService.GetUserByUsername(username);
            List<FlowerSale> flowerSale = context.FlowerSales.Where(x => x.Id == user.Id).ToList();

            return flowerSale;
        }
    }
}