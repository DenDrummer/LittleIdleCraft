using System.Data.Entity;

namespace LIC.DAL
{
    [DbConfigurationType(typeof(LittleIdleCrafterDbConfiguration))]
    internal class LittleIdleCraftDbContext : DbContext
    {
        public LittleIdleCraftDbContext() : base("LittleIdleCraftDB_EFCodeFirst")
        {
        }
    }
}
