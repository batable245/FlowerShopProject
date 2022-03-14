namespace FlowerShop.Services
{
    using Data;
    public class MainService
    {
        private AppDbContext context = new AppDbContext();
        public MainService()
        {
            this.BouquetService = new BouquetService(context);
        }
        public BouquetService BouquetService { get; private set; }
    }
}
