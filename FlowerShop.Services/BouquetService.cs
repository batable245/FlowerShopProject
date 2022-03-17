namespace FlowerShop.Services
{
    using System;
    using Models;
    using Data;
    using System.Collections.Generic;
    using System.Linq;

    public class BouquetService
    {
        private readonly AppDbContext context;
        public BouquetService(AppDbContext context)
        {
            this.context = context;
        }
        //public void CreateBouquet(/*string initialQuantity*/)
        //{
        //    try
        //    {
        //        //Here we will have a list of user added flowers and then we will call the AddFlowersToBouquet method to add them to the bouquet

        //        //if (!int.TryParse(initialQuantity, out _))
        //        //{
        //        //    throw new ArgumentException("Invalid bouquet quantity!");
        //        //}
        //        //int quantity = int.Parse(initialQuantity);


        //        string packageColour = Console.ReadLine();
        //        string packageDesign = Console.ReadLine();
        //        bool HasRibbon = bool.Parse(Console.ReadLine());
        //        //double bouquetPrice = double.Parse(Console.ReadLine());

        //        Bouquet bouquet = new Bouquet()
        //        {
        //            //Quantity = quantity,
        //            //Price = bouquetPrice,
        //            HasRibbon = HasRibbon,
        //            PackageColour = packageColour,
        //            PackageDesign = packageDesign,
        //        };
        //        context.Add(bouquet);
        //        context.SaveChanges();
        //        Console.WriteLine("Bouquet created!");
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine(ex.Message);
        //    }
        //}

        //public void AddFlowersToBouquet(ICollection<Flower> flowers)
        //{

        //}

        //public void DeleteBouquet()
        //{
        //    throw new NotImplementedException();
        //}
        public Bouquet CreateBouquet()
        {
            Bouquet bouquet = new Bouquet()
            {
                Quantity = 1,
                Price = 2,
                HasRibbon = false,
                FlowerQuantity = 0
            };
            context.Bouquets.Add(bouquet);
            context.SaveChanges();
            return bouquet;
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
        public Flower GetFlowerByName(string name)
        {
            return this.context.Flowers.FirstOrDefault(x => x.Name == name);
        }
        public void AddFlowerToBouquet(string flowername, Bouquet newbouquet)
        {
            //Bouquet newbouquet = CreateBouquet();           
            if (GetFlowerByName(flowername) != null)
            {
                Flower flower = GetFlowerByName(flowername);

                BouquetFlower newbouquetflower = new BouquetFlower()
                {
                    Bouquet = newbouquet,
                    Flower = flower,
                    Quantity = 1
                };
                context.BouquetFlowers.Add(newbouquetflower);

                context.SaveChanges();
            }
        }
        public int GetTotalFlowerQuantity(Bouquet bouquet)
        {
            //todo add a check
            int index = 0;
            foreach (BouquetFlower bouquetflowers in GetAllBouquetFlower().Where(x => x.Bouquet.Id == bouquet.Id))
            {
                index = index + bouquetflowers.Quantity;
            }
            return index;
        }
        public void UpdateTotalFlowerQuantity(Bouquet bouquet)
        {
            int flowerquantity = GetTotalFlowerQuantity(bouquet);
             GetBouquetFromId(bouquet.Id);
        }
        public int GetSameFlowerQuantity(Bouquet bouquet)
        {
            int index = 0;
            foreach (BouquetFlower bouquetflowers in GetAllBouquetFlower().Where(x=>x.Bouquet==bouquet))
            {
                index++;
            }
            return index;
        }

    }
}
