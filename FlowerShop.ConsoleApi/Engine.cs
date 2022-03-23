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

        public void AdminPage() //implement functions for flower etc... (He will check all users and edit the flowers)
        {
            while (true)
            {
                try
                {
                    if (!isLogged)
                    {
                        break;
                    }
                    Console.Write("Select U (Show app users), D (Delete), L (Logout): ");
                    string option = Console.ReadLine().ToUpper();
                    switch (option)
                    {
                        case "U":
                            UserList();
                            break;
                        case "L":
                            LogOut();
                            break;
                        case "D":
                            DeleteUser();
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

        private void DeleteUser()
        {
            Console.WriteLine("Enter user to delete: ");
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
                    //First 3 commands are optional. MVP is most important Select CU (Change username), AB (Add balance)
                    Console.Write("Select CP (Change password), BF (Buy flower), PF (See all purchased flowers), L (LogOut): ");
                    string option = Console.ReadLine().ToUpper();
                    switch (option)
                    {
                        case "CP":
                            //see caching issue
                            ChangePassword(appUser);
                            break;
                        case "CU":

                            break;
                        case "AB":

                            break;
                        case "BF":
                            //flowerService.buy
                            break;
                        case "PF":


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

        public void FlowerList() //flowerList for bought flowers
        {
            StringBuilder sb = new StringBuilder();
            ICollection<FlowerService> flowers = (ICollection<FlowerService>)main.SalesService.GetPurchasedFlowersByUser(appUser);
            if (flowers.Any())
            {
                //sb.AppendLine(output.PrintFlowers(flowers, "Your flowers")); -> collision between FlowerService and FlowerSale

            }
        }

        public void ChangePassword(string username)
        {
            //null reference exception, because of the warning
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
