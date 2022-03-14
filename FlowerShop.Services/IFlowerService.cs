using FlowerShop.Models;
using System.Collections.Generic;
namespace FlowerShop.Services
{
    public interface IFlowerService
    {
        public ICollection<Flower> GetAllFlowers();
        public void AddFlower(string name, string price, int quantity);
        public void UpdateFlower();
        public void DeleteFlower();
    }
}
