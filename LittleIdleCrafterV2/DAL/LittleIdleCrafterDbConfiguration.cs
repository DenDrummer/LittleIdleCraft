using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.SqlServer;

namespace LIC.DAL
{
    internal class LittleIdleCrafterDbConfiguration : DbConfiguration
    {
        public LittleIdleCrafterDbConfiguration()
        {
            SetDefaultConnectionFactory(new SqlConnectionFactory());
            SetProviderServices("System.Data.SqlClient", SqlProviderServices.Instance);
            SetDatabaseInitializer(new LittleIdleCraftDbInitializer());
        }
    }
}
