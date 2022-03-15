namespace FlowerShop.Services
{
    using Models;
    using Data;
    using System.Collections.Generic;
    using System.Linq;
    using System;

    public class BouquetService
    {
        private readonly AppDbContext context;
        public BouquetService(AppDbContext context)
        {
            this.context = context;
        }
        public void CreateBouquet(/*string initialQuantity*/)
        {
            try
            {
                //if (!int.TryParse(initialQuantity, out _))
                //{
                //    throw new ArgumentException("Invalid bouquet quantity!");
                //}
                //int quantity = int.Parse(initialQuantity);
                string packageColour = Console.ReadLine();
                string packageDesign = Console.ReadLine();
                bool HasRibbon = bool.Parse(Console.ReadLine());
                //double bouquetPrice = double.Parse(Console.ReadLine());

                Bouquet bouquet = new Bouquet()
                {
                    //Quantity = quantity,
                    //Price = bouquetPrice,
                    HasRibbon = HasRibbon,
                    PackageColour = packageColour,
                    PackageDesign = packageDesign,
                };
                context.Add(bouquet);
                context.SaveChanges();
                Console.WriteLine("Bouquet created!");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public void AddBouquet()
        {
            throw new NotImplementedException();
        }

        public void AddFlowerToBouquet(string flowerName, int quantity)
        {
            throw new NotImplementedException();
        }

        public void DeleteBouquet()
        {
            throw new NotImplementedException();
        }

        public Bouquet GetBouquetFromId(int id)
        {
            return this.context.Bouquets.FirstOrDefault(x => x.Id == id);
        }
        public ICollection<Bouquet> GetAllBouquets()
        {
            return this.context.Bouquets.ToList();
        }
        public ICollection<BouquetFlower> GetAllBouquetFlower()
        {
            return this.context.BouquetFlowers.ToList();
        }
        

        public void RemoveFlowerFromBouquet(string flowerName, int quantity)
        {
            throw new NotImplementedException();
        }

        public void UpdateBouquet()
        {
            throw new NotImplementedException();
        }

        public void WrapBouquet(string ribbon = "Red", string packageColour = "Golden", string packageDesign = "Clean")
        {
            throw new NotImplementedException();
        }
    }
}
