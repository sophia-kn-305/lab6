using System.Data.Entity;
using Lab6.Models;

namespace Lab06.App_Start
{
    public class MyDbContext : DbContext
    {
        public MyDbContext() : base("name=study") { }
        public virtual DbSet<Seller> Sellers { get; set; }
        public virtual DbSet<Carrier> Carriers { get; set; }
        public virtual DbSet<Store> Stores { get; set; }
        public virtual DbSet<Delivery> Deliveries { get; set; }
    }
}