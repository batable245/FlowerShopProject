using System;
using System.ComponentModel.DataAnnotations;


namespace FlowerShop.Data.Models
{
    public class FlowerSale
    {
        [Required, Key]
        public int Id { get; set; }
        public DateTime Date { get; set; }

        [Required]
        public double Price { get; set; }

        [Required]
        public int Quantity { get; set; }
        public User User { get; set; }
        public Flower Flower { get; set; }

    }
}
