

using System.Collections.Generic;

namespace FlowerShop.Services
{
using Models;
    public interface IBouquetService
    {
        public ICollection<Bouquet> GetAllBouquets();
        //public void AddBouquet();
        public void UpdateBouquet();
        public void DeleteBouquet();
        public void AddFlowerToBouquet(string flowerName);
        public void RemoveFlowerFromBouquet(string flowerName, int quantity);
        public void GetPurchasedBouquetsByUser(string username);

    }
}
