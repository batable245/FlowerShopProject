using FlowerShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace FlowerShop.Services
{
    public class OutputService
    {
        public string PrintUsers(ICollection<User> users, string message = null)
        {
            StringBuilder sb = new StringBuilder();
            AddTableTitle(message, sb);
            string header = $"| {"Id",-6} | {"Username",-20} | {"Balance",-8} | {"Register date",-15} |";
            sb.AppendLine(header);
            sb.AppendLine(Border(header.Length));

            foreach (var user in users)
            {
                sb.AppendLine($"| {user.Id, -6} | {user.Username, -20} | {Math.Round(user.Balance, 2), -8} | {user.RegisterDate.ToShortDateString(), -15} |");
                sb.AppendLine(Border(header.Length));
            }
            return sb.ToString().TrimEnd();
        }

        public string PrintFlowers(ICollection<Flower> flowers, string message = null)
        {
            StringBuilder sb = new StringBuilder();
            AddTableTitle(message, sb);
            string header = $"| {"Id", -6} | {"Name", -25} | {"Price", -8} | {"Quantity", -12} |";
            sb.AppendLine(header);
            sb.AppendLine(Border(header.Length));

            foreach (var flower in flowers)
            {
                sb.AppendLine($"| {flower.Id,-6} | {flower.Name,-25} | {Math.Round(flower.Price, 2), - 8} | {flower.Quantity, -12} |");
                sb.AppendLine(Border(header.Length));
            }
            return sb.ToString().TrimEnd();
        }

        public string PrintFlowerSales(ICollection<FlowerSale> sales, string message = null)
        {
            StringBuilder sb = new StringBuilder();
            AddTableTitle(message, sb);
            string header = $"| {"Id", -5} | {"Quantity", -10} | {"FlowerName", -25} |";
            sb.AppendLine(header);

            sb.AppendLine(Border(header.Length));

            foreach (var sale in sales)
            {
                sb.AppendLine($"| {sale.Id, -5} | {sale.Quantity, -10} | {sale.Flower.Name, -25} |");
                sb.AppendLine(Border(header.Length));
            }
            return sb.ToString().TrimEnd();
        }

        private static void AddTableTitle(string message, StringBuilder sb)
        {
            if (message != null)
            {
                sb.AppendLine($"-- {message} --");
            }
        }
        private static string Border(int size)
        {
            return $"|{new string('-', size - 2)}|";
        }
    }
}
