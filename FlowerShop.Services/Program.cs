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
            //sales.BuyFlower("Rose", 2, "Ilian");
            //flower.UpdateFlowerPrice("Rose", "4");
            //sales.GetPurchasedFlowersByUser("Ivcho");
            //user.CreateUser("Batman", "Batman1", "88");
            user.GetUserById(1008);
        }
    }
}
