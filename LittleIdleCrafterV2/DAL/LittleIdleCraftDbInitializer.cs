using System.Data.Entity;

namespace LIC.DAL
{
    internal class LittleIdleCraftDbInitializer : DropCreateDatabaseIfModelChanges<LittleIdleCraftDbContext>
    {
        protected override void Seed(LittleIdleCraftDbContext ctx)
        {
            base.Seed(ctx);
        }
    }
}
