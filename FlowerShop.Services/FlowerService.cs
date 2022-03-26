namespace FlowerShop.Services
{
    using Models;
    using Data;
    using System.Collections.Generic;
    using System.Linq;
    using System;
    using Microsoft.EntityFrameworkCore;

    public class FlowerService : IFlowerService
    {
        private readonly AppDbContext context;
        public FlowerService(AppDbContext context)
        {
            this.context = context;
        }
        public Flower GetFlowerByName(string name)
        {
            Flower flower = this.context.Flowers.FirstOrDefault(x => x.Name == name);
            if (flower != null)
            {
                context.Entry(flower).State = EntityState.Detached;
            }
            return flower;
        }

        public ICollection<Flower> GetAllFlowersNames(int page = 1, int itemsPerPage = 10)
        {
            return this.context.Flowers
                .Skip((page - 1) * itemsPerPage)
                .Take(itemsPerPage)
                .AsNoTracking()
                .ToList();
        }

        public void AddFlower(string name, string price, string quantity)
        {

            if (string.IsNullOrWhiteSpace(name) || !double.TryParse(price, out _) || !int.TryParse(quantity, out _))
            {
                throw new ArgumentException("Invalid flower params!");
            }
            if (GetFlowerByName(name) != null)
            {
                throw new Exception("Flower already exists!");
            }
            Flower flower = new Flower()
            {
                Name = name,
                Price = double.Parse(price),
                Quantity = int.Parse(quantity)
            };
            context.Flowers.Add(flower);
            context.SaveChanges();
        }

        public void DeleteFlower(string name)
        {
            Flower flower = GetFlowerByName(name);
            if (flower == null)
            {
                throw new Exception("Flower not found");
            }
            context.Flowers.Attach(flower);
            context.Flowers.Remove(flower);
            context.SaveChanges();

        }

        public ICollection<Flower> GetAllFlowers()
        {
            return this.context.Flowers.AsNoTracking().ToList();
        }
#nullable enable
        public void UpdateFlower(string searchname, string? name = null,
            string? price = null, string? quantity = null)
        {
            if (string.IsNullOrWhiteSpace(searchname))
            {
                throw new ArgumentException("Flower not found");
            }
            Flower flower = GetFlowerByName(searchname);
            if (!string.IsNullOrEmpty(name))
            {
                flower.Name = name;
            }
            if (!string.IsNullOrEmpty(price))
            {
                if (double.TryParse(price, out _))
                {
                    flower.Price = double.Parse(price);
                }
            }
            if (!string.IsNullOrEmpty(quantity))
            {
                if (int.TryParse(quantity, out _))
                {
                    flower.Quantity = int.Parse(quantity);
                }
            }
            context.SaveChanges();
        }

        public void UpdateFlowerPrice(string flowerName, string newPrice)
        {
            if (string.IsNullOrWhiteSpace(flowerName))
            {
                throw new ArgumentException("Flower not found");
            }
            if (string.IsNullOrWhiteSpace(newPrice) || !double.TryParse(newPrice, out _) || double.Parse(newPrice) <= 0)
            {
                throw new ArgumentException("Invalid flower price");
            }
            Flower flower = GetFlowerByName(flowerName);
            double price = double.Parse(newPrice);
            flower.Price = price;
            context.Update(flower);
            context.SaveChanges();
        }

        public void UpdateFlowerQuantity(string flowerName, string newQuantity)
        {
            if (string.IsNullOrWhiteSpace(flowerName))
            {
                throw new ArgumentException("Flower not found");
            }
            if (string.IsNullOrWhiteSpace(newQuantity) || !int.TryParse(newQuantity, out _) || int.Parse(newQuantity) <= 0)
            {
                throw new ArgumentException("Invalid flower quantity");
            }
            Flower flower = GetFlowerByName(flowerName);
            int quantity = int.Parse(newQuantity);
            flower.Quantity = quantity;
            context.Update(flower);
            context.SaveChanges();
        }
        
#nullable disable
    }
}
