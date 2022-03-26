using FlowerShop.Data;
using System;

namespace DataProcessor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DataSeeder seeder = new DataSeeder();
            seeder.Run();
        }
    }
}
