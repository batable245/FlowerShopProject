using System;

namespace FlowerShop.ConsoleApi
{
    using FlowerShop.Data;
    using Models;
    using Services;
    using System.Collections.Generic;

    internal class Program
    {
        static void Main(string[] args)
        {
            AppDbContext context = new AppDbContext();

            Engine engine = new Engine(context);

        }
    }
}
