
namespace FlowerShop.Services
{
    public interface ISaleService
    {
        public void BuyFlower(string flowerName, int quantity, string username);
        public void BuyBouquet(int id, string username);
    }
}
