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
            this.UserService = new UserService(context);
        }
        //alishov login method
        //public UsersService Users { get; private set; }
        //public ScootersService Scooters { get; private set; }
        //public RentsService Rents { get; private set; }
        //public OutputService Output { get; private set; }
        //public bool IsLogged { get; private set; }
        //public bool IsAdmin { get; set; }
        //public string AppUser { get; private set; }

        //public void Logout()
        //{
        //    this.IsAdmin = false;
        //    this.IsLogged = false;
        //    this.AppUser = null;
        //}
        //public string Login(string username, string password)
        //{
        //    try
        //    {
        //        IsLogged = Users.Login(username, password);
        //        if (IsLogged)
        //        {
        //            AppUser = username;
        //            if (AppUser == "admin")
        //            {
        //                IsAdmin = true;
        //            }
        //            return "Login complete";
        //        }
        //        return "Try again!";
        //    }
        //    catch (System.Exception ex)
        //    {
        //        return ex.Message;
        //    }

        //}
        public BouquetService BouquetService { get; private set; }
        public FlowerService FlowerService { get; private set; }
        public UserService UserService { get; private set; }
    }
}
