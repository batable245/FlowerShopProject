using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace FlowerShop.Models
{
    public class User
    {
        [Required, Key]
        public int Id { get; set; }
        public DateTime RegisterDate { get; set; }

        [Required, MaxLength(40)]
        public string Username { get; set; }

        [Required, MinLength(4)]
        public string Password { get; set; }
        public double Balance { get; set; }
        public Role Role { get; set; }
        public virtual ICollection<BouquetSale> BouquetSales { get; set; } = new HashSet<BouquetSale>();
        public virtual ICollection<FlowerSale> FlowerSales { get; set; } = new HashSet<FlowerSale>();

    }

    public enum Role { ADMIN, USER, ANONYMOUS }
}
