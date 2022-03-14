namespace FlowerShop.Services
{
    using Data;
    public class MainService
    {
        private AppDbContext context = new AppDbContext();
        public MainService()
        {
            this.BouquetService = new BouquetService(context);
            this.FlowerService = new FlowerService(context);
        }
        public BouquetService BouquetService { get; private set; }
        public FlowerService FlowerService { get; private set; }
    }
}
