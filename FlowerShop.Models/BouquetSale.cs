using System;
using System.ComponentModel.DataAnnotations;


namespace FlowerShop.Models
{
    public class BouquetSale
    {
        [Required, Key]
        public int Id { get; set; }
        public DateTime Date { get; set; }

        [Required]
        public double Price { get; set; }

        [Required]
        public int Quantity { get; set; }
        public User User { get; set; }
        public Bouquet Bouquet { get; set; }

    }
}
