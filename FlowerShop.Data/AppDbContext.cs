using FlowerShop.Models;
using Microsoft.EntityFrameworkCore;


namespace FlowerShop.Data
{
    public class AppDbContext : DbContext
    {
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Flower> Flowers { get; set; }
        public virtual DbSet<Bouquet> Bouquets { get; set; }
        public virtual DbSet<FlowerSale> FlowerSales { get; set; }
        public virtual DbSet<BouquetSale> BouquetSales { get; set; }
        public virtual DbSet<BouquetFlower> BouquetFlowers { get; set; }

        private const string ConnectionString = "Server=.;Database=FlowerShopDb;Trusted_Connection=True;";
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasIndex(u => u.Username)
                .IsUnique();

        }
    }
}
