using System;
using System.ComponentModel.DataAnnotations;


namespace FlowerShop.Models
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
        public int UserId { get; set; }
        public virtual User User { get; set; }
        public int FlowerId { get; set; }
        public virtual Flower Flower { get; set; }

    }
}
