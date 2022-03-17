using FlowerShop.Data;
using System;

namespace FlowerShop.Services
{
    internal class Program
    {
        static void Main(string[] args)
        {
            AppDbContext context = new AppDbContext();

            UserService user = new UserService(context);
            FlowerService flower = new FlowerService(context);
            SaleService sales = new SaleService(context, flower, user);

            //flower.UpdateFlower("Rose", "Rose", "5", "15");
            //sales.BuyFlower("Rose", 3, "Ivcho");
        }
    }
}
