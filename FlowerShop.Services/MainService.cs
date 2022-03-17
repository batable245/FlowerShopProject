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
        //public OutputService Output { get; private set; } -> need to implement

        public bool IsLogged { get; private set; }
        public bool IsAdmin { get; private set; }
        public string AppUser { get; private set; }

        public void Logout()
        {
            this.IsAdmin = false;
            this.IsLogged = false;
            this.AppUser = null;
        }
        public string LogIn(string username, string password)
        {
            try
            {
                IsLogged = UserService.LogIn(username, password);
                if (IsLogged)
                {
                    AppUser = username;
                    if (AppUser == "admin")
                    {
                        IsAdmin = true;
                    }
                    return "Login complete";
                }
                return "Try again!";
            }
            catch (System.Exception ex)
            {
                return ex.Message;
            }

        }
        public BouquetService BouquetService { get; private set; }
        public FlowerService FlowerService { get; private set; }
        public UserService UserService { get; private set; }
    }
}
