namespace FlowerShop.Services
{
    using Models;
    using Data;
    using System.Collections.Generic;
    using System.Linq;
    using System;

    public class BouquetService : IBouquetService
    {
        private readonly AppDbContext context;
        public BouquetService(AppDbContext context)
        {
            this.context = context;
        }
        public void AddBouquet()
        {
            throw new NotImplementedException();
        }

        public void AddFlowerToBouquet(string flowerName, int quantity)
        {
            throw new NotImplementedException();
        }

        public void DeleteBouquet()
        {
            throw new NotImplementedException();
        }

        public ICollection<Bouquet> GetAllBouquets()
        {
            return this.context.Bouquets.ToList();
        }

        public void RemoveFlowerFromBouquet(string flowerName, int quantity)
        {
            throw new NotImplementedException();
        }

        public void UpdateBouquet()
        {
            throw new NotImplementedException();
        }

        public void WrapBouquet(string ribbon = "Red", string packageColour = "Golden", string packageDesign = "Clean")
        {
            throw new NotImplementedException();
        }
    }
}
