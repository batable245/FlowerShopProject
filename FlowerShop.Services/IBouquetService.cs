

namespace FlowerShop.Services
{
    public interface IBouquetService
    {
        public void GetAllBouquets();
        public void AddBouquet();
        public void UpdateBouquet();
        public void DeleteBouquet();
        public void AddFlowerToBouquet(string flowerName, int quantity);
        public void RemoveFlowerFromBouquet(string flowerName, int quantity);
        public void WrapBouquet(string ribbon = "Red", string packageColour = "Golden", string packageDesign = "Clean");
    }
}
