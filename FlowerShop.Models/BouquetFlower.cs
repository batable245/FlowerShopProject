using System.ComponentModel.DataAnnotations;


namespace FlowerShop.Models
{
    public class BouquetFlower
    {
        [Required, Key]
        public int Id { get; set; }

        [Required]
        public int Quantity { get; set; }
        public Bouquet Bouquet { get; set; }
        public Flower Flower { get; set; }

    }
}
