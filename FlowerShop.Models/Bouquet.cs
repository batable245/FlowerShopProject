using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace FlowerShop.Data.Models
{
    public class Bouquet
    {
        [Required, Key]
        public int Id { get; set; }

        [Required]
        public int Quantity { get; set; }
        public double Price { get; set; }
        public bool HasRibbon { get; set; }
        public string PackageColour { get; set; }
        public string PackageDesign { get; set; }
        public virtual ICollection<BouquetSale> BouquetSales { get; set; } = new HashSet<BouquetSale>();
        public virtual ICollection<BouquetFlower> BouquetFlowers { get; set; } = new HashSet<BouquetFlower>();

    }
}