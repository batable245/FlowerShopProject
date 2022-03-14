namespace FlowerShop.Services
{
    using Models;
    using Data;
    using System.Collections.Generic;
    using System.Linq;
    using System;
    public class FlowerService
    {
        private readonly AppDbContext context;
        public FlowerService(AppDbContext context)
        {
            this.context = context;
        }

        public Flower GetFlowerByName(string name)
        {
            return this.context.Flowers.FirstOrDefault(x => x.Name == name);
        }
        public void AddFlower(string name, string price, int quantity)
        {
            if (string.IsNullOrWhiteSpace(name) || !double.TryParse(price, out _))
            {
                throw new ArgumentException("Invalid Flower params!");
            }
            if (GetFlowerByName(name) != null)
            {
                throw new Exception("Flower already exists!");
            }
            Flower flower = new Flower()
            {
                Name = name,
                Price = double.Parse(price),
                Quantity = quantity
            };
            context.Flowers.Add(flower);
            context.SaveChanges();
        }
        public void DeleteFlower(string name)
        {
            Flower flower = GetFlowerByName(name);
            if (flower != null)
            {
                context.Flowers.Remove(flower);
                context.SaveChanges();
            }
        }
        public ICollection<Flower> GetAllFlowers()
        {
            return this.context.Flowers.ToList();
        }

        public void UpdateFlower()
        {
            throw new NotImplementedException();
        }
    }
}
