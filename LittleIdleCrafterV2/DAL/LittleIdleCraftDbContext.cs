using LIC.BL.Domain;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace LIC.DAL
{
    [DbConfigurationType(typeof(LittleIdleCrafterDbConfiguration))]
    internal class LittleIdleCraftDbContext : DbContext
    {
        public LittleIdleCraftDbContext() : base("LittleIdleCraftDB_EFCodeFirst")
        {
        }

        public DbSet<Item> Items { get; set; }
        public DbSet<Crafter> Crafters { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // remove pluralizing tablenames
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            // remove cascading delete for all required relationships
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            // make sure the primary keys are right (better safe than sorry)
            modelBuilder.Entity<Item>().HasKey(i => i.Id);
            modelBuilder.Entity<Crafter>().HasKey(c => c.Id);
        }
    }
}
