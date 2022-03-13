using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace FlowerShop.Data.Models
{
    public class Flower
    {
        [Required, Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public double Price { get; set; }

        [Required]
        public int Quantity { get; set; }
        public virtual ICollection<FlowerSale> FlowerSales { get; set; } = new HashSet<FlowerSale>();
        public virtual ICollection<BouquetFlower> BouquetFlowers { get; set; } = new HashSet<BouquetFlower>();

    }
}
