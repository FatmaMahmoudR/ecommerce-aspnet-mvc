using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace E_commerce.Models
{
    public class EcommerceCountext : DbContext
    {
        public DbSet<Seller> Sellers { get; set; }
        public DbSet<Buyer> Buyers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Card> Cards { get; set; }
        public DbSet<OrderedProduct> OrderedProducts { get; set; }
        public DbSet<ShippingInfo> Shippings { get; set; }
       

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=FATMA\\MSSQLSERVERR;Database=ecommerceITI" +
                ";Trusted_Connection=True;Encrypt=True;TrustServerCertificate=True");

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<CrsResult>().HasKey(vf => new { vf.crsid, vf.traineeid });
        }
    }
}
