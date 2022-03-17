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
        //check if I need this constructor
        public SaleService(AppDbContext context, FlowerService flowerService, UserService userService)
        {
            this.context = context;
            this.flowerService = flowerService;
            this.userService = userService;
        }
        public void BuyBouquet(int id, string username)
        {
            throw new NotImplementedException();
        }

        public void BuyFlower(string flowerName, int quantity, string username)
        {
            Flower flower = GetFlowerByName(flowerName);
            User user = GetUserByUsername(username);
            if (flower == null)
            {
                throw new ArgumentException("Flower not found!");
            }
            //if ()
            //{

            //}


        }

        public Flower GetFlowerByName(string name)
        {
            return this.context.Flowers.FirstOrDefault(x => x.Name == name);
        }
        public User GetUserByUsername(string username)
        {
            User user = this.context.Users.Where(x => x.Username == username).FirstOrDefault();
            return user;
        }
    }
}
