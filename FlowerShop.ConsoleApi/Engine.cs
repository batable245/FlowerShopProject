using FlowerShop.Data;
using FlowerShop.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowerShop.ConsoleApi
{
    public class Engine
    {
        private MainService main;
        private OutputService output;
        private readonly AppDbContext context;
        private static bool isLogged = false;
        private static string appUser = null;
        private static UserService userService;
        private static FlowerService flowerService;
        private static SaleService saleService;
        public Engine(AppDbContext context)
        {
            this.context = context;
            main = new MainService();
            output = new OutputService();
            userService = new UserService(context);
            flowerService = new FlowerService(context);
            saleService = new SaleService(context, flowerService, userService);
            Run();
        }

        public void Run()
        {
            while (true)
            {
                try
                {
                    if (appUser == "admin" && isLogged)
                    {
                        AdminPage();
                    }
                    else if (isLogged)
                    {
                        UserPage();
                    }
                    else
                    {
                        LoginOrRegister();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        public void AdminPage() 
        {
            while (true)
            {
                try
                {
                    if (!isLogged)
                    {
                        break;
                    }
                    Console.Write("Select U (Show app users), AF (Add flower), FL (Flower list), UFP (Update flower price), UFQ (Update flower quantity), DU (Delete user), DF (Delete flower), L (Logout): ");
                    string option = Console.ReadLine().ToUpper();
                    switch (option)
                    {
                        case "U":
                            UserList();
                            break;
                        case "AF":
                            AddFlower();
                            break;
                        case "L":
                            LogOut();
                            break;
                        case "DU":
                            DeleteUser();
                            break;
                        case "FL":
                            FlowerList();
                            break;
                        case "UFP":
                            UpdateFlowerPrice();
                            break;
                        case "UFQ":
                            UpdateFlowerQuantity();
                            break;
                        case "DF":
                            DeleteFlower();
                            break;
                        default:
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        private void DeleteFlower()
        {
            Console.Write("Enter flower name: ");
            string flowerName = Console.ReadLine();
            flowerService.DeleteFlower(flowerName);
            Console.WriteLine("Flower deleted");
        }

        private void UpdateFlowerQuantity()
        {
            Console.Write("Enter flower name: ");
            string flowerName = Console.ReadLine();
            Console.Write("Enter new flower quantity: ");
            string newQuantity = Console.ReadLine();
            flowerService.UpdateFlowerQuantity(flowerName, newQuantity);
        }

        private void UpdateFlowerPrice()
        {
            Console.Write("Enter flower name: ");
            string flowerName = Console.ReadLine();
            Console.Write("Enter new flower price: ");
            string newPrice = Console.ReadLine();
            flowerService.UpdateFlowerPrice(flowerName, newPrice);
        }

        private void AddFlower()
        {
            Console.Write("Enter flower name: ");
            string flowerName = Console.ReadLine();
            Console.Write("Enter flower price: ");
            string flowerPrice = Console.ReadLine();
            Console.Write("Enter flower quantity: ");
            string flowerQuantity = Console.ReadLine();
            flowerService.AddFlower(flowerName, flowerPrice, flowerQuantity);
        }

        private void DeleteUser()
        {
            Console.Write("Enter user to delete: ");
            string name = Console.ReadLine();
            if (name == appUser)
            {
                Console.WriteLine("Cannot delete admin user!");
                return;
            }
            var user = userService.GetUserByUsername(name);
            if (user == null)
            {
                Console.WriteLine("User does not exist!");
                return;
            }
            userService.DeleteUserByUsername(name);
            Console.WriteLine("User deleted successfully!");
        }

        public void UserList()
        {
            int page = 1;
            int totalPages = (int)Math.Ceiling(main.UserService.GetUsersCount() / 10.0);
            while (true)
            {
                string users = output.PrintUsers(main.UserService.GetAllUsersUsernames(page), $"User list - page {page} / {totalPages}");
                Console.WriteLine(users);
                Console.WriteLine("P (Previous page), N (Next page), B (Back)");
                string option = ReadInput("Select option: ").ToUpper();
                switch (option)
                {
                    case "P":
                        if (page > 1)
                        {
                            page--;
                        }
                        break;
                    case "N":
                        if (page < totalPages)
                        {
                            page++;
                        }
                        break;
                    default:
                        break;
                }
                if (option == "B")
                {
                    break;
                }
            }
        }

        public void UserPage()
        {
            while (true)
            {
                try
                {
                    if (!isLogged)
                    {
                        break;
                    }
                    Console.Write("Select CP (Change password), CU (Change username), AB (Add balance), FL (Flower list), BF (Buy flower), PF (See all purchased flowers), L (LogOut): ");
                    string option = Console.ReadLine().ToUpper();
                    switch (option)
                    {
                        case "CP":
                            ChangePassword(appUser);
                            break;
                        case "CU":
                            ChangeUsername(appUser);
                            break;
                        case "AB":
                            AddBalance(appUser);
                            break;
                        case "BF":
                            BuyFlower();
                            break;
                        case "PF":
                            PurchasedFlowers();
                            break;
                        case "FL":
                            FlowerList();
                            break;
                        case "L":
                            LogOut();
                            break;
                        default:
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        private void PurchasedFlowers()
        {
            StringBuilder sb = new StringBuilder();
            var sales = main.SalesService.GetPurchasedFlowersByUser(appUser);
            if (sales.Any())
            {
                sb.AppendLine(output.PrintFlowerSales(sales, "Your flower purchase history"));
            }
            else
            {
                sb.AppendLine("No purchase history");
            }
            Console.WriteLine(sb.ToString().TrimEnd());
        }

        public void BuyFlower()
        {
            Console.Write("Enter flower name: ");
            string flowerName = Console.ReadLine();
            Console.Write("Enter flower quantity: ");
            string _flowerQuantity = Console.ReadLine();
            if (!int.TryParse(_flowerQuantity, out _) || string.IsNullOrWhiteSpace(_flowerQuantity) || int.Parse(_flowerQuantity) <= 0)
            {
                throw new ArgumentException("Invalid flower quantity!");
            }

            int flowerQuantity = int.Parse(_flowerQuantity);
            saleService.BuyFlower(flowerName, flowerQuantity, appUser);
        }

        public void AddBalance(string username)
        {
            Console.Write("Enter balance to add: ");
            string balance = Console.ReadLine();
            userService.AddBalance(username, balance);
        }

        public void ChangeUsername(string username)
        {
            Console.Write("Enter new username: ");
            string newUsername = Console.ReadLine();
            userService.ChangeUsername(username, newUsername);
        }

        public void FlowerList()
        {
            int page = 1;
            int totalPages = (int)Math.Ceiling(main.FlowerService.GetAllFlowers().Count() / 10.0);
            while (true)
            {
                string flowers = output.PrintFlowers(main.FlowerService.GetAllFlowersNames(page), $"Flower list - page {page} / {totalPages}");
                Console.WriteLine(flowers);
                Console.WriteLine("P (Previous page), N (Next page), B (Back)");
                string option = ReadInput("Select option: ").ToUpper();
                switch (option)
                {
                    case "P":
                        if (page > 1)
                        {
                            page--;
                        }
                        break;
                    case "N":
                        if (page < totalPages)
                        {
                            page++;
                        }
                        break;
                    default:
                        break;
                }
                if (option == "B")
                {
                    break;
                }
            }
        }

        public void ChangePassword(string username)
        {
            Console.Write("Enter new password: ");
            string newPassword = Console.ReadLine();
            userService.ChangePassword(appUser, newPassword);
        }

        public void LoginOrRegister()
        {
            while (true)
            {
                if (isLogged)
                {
                    break;
                }
                Console.Write("Select L (Login) or R (Register), E (Exit): ");
                string option = Console.ReadLine().ToUpper();
                switch (option)
                {
                    case "L":
                        LoginPage();
                        break;
                    case "R":
                        RegisterPage();
                        break;
                    case "E":
                        Environment.Exit(0);
                        break;
                    default:
                        break;
                }

            }
        }

        public void RegisterPage()
        {
            Console.WriteLine($"-- Register page --");
            try
            {
                string username = ReadInput("Enter username: ");
                string password = ReadInput("Enter password: ");
                string balance = ReadInput("Enter initial balance: ");

                main.UserService.CreateUser(username, password, balance);
                appUser = username;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.WriteLine($"Successfully registered!");
        }

        public void LoginPage()
        {
            Console.WriteLine($"-- Login page --");

            while (!isLogged)
            {
                try
                {
                    Console.Write(">Enter username: ");
                    string username = Console.ReadLine();
                    Console.Write(">Enter password: ");
                    string password = Console.ReadLine();
                    if (main.UserService.LogIn(username, password))
                    {
                        isLogged = true;
                        appUser = username;
                        Console.Clear();
                        Console.WriteLine($"User: {username}");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                if (!isLogged)
                {
                    Console.WriteLine("Invalid username or password! Try again!");
                }
            }
        }

        private string ReadInput(string message)
        {
            Console.Write($">{message}");
            return Console.ReadLine();
        }

        public void LogOut()
        {
            isLogged = false;
            appUser = null;
        }

    }
}
