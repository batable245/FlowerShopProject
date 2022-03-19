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
            string header = $"|{"Id",-5} | {"Name",-25} | {"Balance",-8} | {"Register date",-15}";
            sb.AppendLine(header);
            sb.AppendLine(Border(header.Length));

            foreach (var user in users)
            {
                sb.AppendLine($"{user.Id, -5} | {user.Username, -25} | {Math.Round(user.Balance, 2) -8} | {user.RegisterDate.ToShortDateString(), -15}");
                sb.AppendLine(Border(header.Length));
            }
            return sb.ToString().TrimEnd();
        }

        public string PrintFlowers(ICollection<Flower> flowers, string message = null)
        {
            StringBuilder sb = new StringBuilder();
            AddTableTitle(message, sb);
            string header = $"|{"Id", -5} | {"Name", -25} | {"Price", -8} | {"Quantity", -8}";
            sb.AppendLine(header);
            sb.AppendLine(Border(header.Length));

            foreach (var flower in flowers)
            {
                sb.AppendLine($"{flower.Id,-5} | {flower.Name,-25} | {Math.Round(flower.Price, 2) - 8} | {flower.Quantity, -8}");
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
