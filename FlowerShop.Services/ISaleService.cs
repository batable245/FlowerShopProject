
using FlowerShop.Models;
using System.Collections.Generic;

namespace FlowerShop.Services
{
    public interface ISaleService
    {
        public void BuyFlower(string flowerName, int quantity, string username);
        //public void BuyBouquet(int id, string username);
        public List<FlowerSale> GetPurchasedFlowersByUser(string username);
    }
}
