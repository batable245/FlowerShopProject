using FlowerShop.Models;
using System.Collections.Generic;
namespace FlowerShop.Services
{
    public interface IFlowerService
    {
#nullable enable
        public ICollection<Flower> GetAllFlowers();
        public void AddFlower(string name, string price, int quantity);
        public Flower GetFlowerByName(string name);
        public void DeleteFlower(string name);
        public void UpdateFlower(string searchname, string? name = null,
            string? price = null, string? quantity = null);

    }
}
