using System;

namespace FlowerShop.ConsoleApi
{
    using Models;
    using Services;
    using System.Collections.Generic;

    internal class Program
    {
        static void Main(string[] args)
        {
            MainService service = new MainService();
            ICollection<Bouquet> bouquets = service.BouquetService.GetAllBouquets();
            foreach (var item in bouquets)
            {
                Console.WriteLine($"id:{item.Id}\nQuantity:{item.Quantity}\nPrice:{item.Price}");
            }
        }
    }
}
