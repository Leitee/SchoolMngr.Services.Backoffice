namespace SchoolMngr.Services.Backoffice.DAL.Context
{
    using Codeit.Enterprise.Base.Abstractions.DataAccess;
    using Codeit.Enterprise.Base.DataAccess;
    using Microsoft.EntityFrameworkCore;
    using SchoolMngr.Infrastructure.Shared.Configuration;

    public class BackofficeDbContextFactory : DesignTimeDbContextFactoryBase<BackofficeDbContext>
    {
        public BackofficeDbContextFactory() : base(SharedHostConfiguration.BuildDefaultSettings())
        {
        }

        protected override BackofficeDbContext CreateNewInstance(DbContextOptions<BackofficeDbContext> options)
        {
            return new BackofficeDbContext(options);
        }

        protected override IPersistenceBuilder CreatePersistenceBuilder(DALSettings settings)
        {
            return EFPersistenceBuilder.Build(settings);
        }
    }
}
