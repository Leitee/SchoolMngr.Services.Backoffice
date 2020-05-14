using Microsoft.EntityFrameworkCore;

namespace SchoolMngr.BackOffice.DAL
{
    public class SchoolDbContextFactory : DesignTimeDbContextFactoryBase<SchoolDbContext>
    {
        protected override SchoolDbContext CreateNewInstance(DbContextOptions<SchoolDbContext> options)
        {
            return new SchoolDbContext(options);
        }
    }
}
