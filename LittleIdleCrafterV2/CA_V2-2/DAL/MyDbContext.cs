using System.Data.Entity;

namespace LIC
{
    public class MyDbContext : DbContext
    {
        public DbSet<Item> Items { get; set; }
        public DbSet<Crafter> Crafters { get; set; }
        public MyDbContext() : base("name=MyConnString")
        {
            Database.SetInitializer<MyDbContext>(new MyDbInitializer());
            Configuration.LazyLoadingEnabled = true;
            Configuration.ProxyCreationEnabled = true;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);
        }
    }
}