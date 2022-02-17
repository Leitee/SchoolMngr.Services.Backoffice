
namespace SchoolMngr.Services.Backoffice.DAL.Context
{
    using Codeit.Enterprise.Base.Abstractions.DataAccess;
    using Codeit.Enterprise.Base.DataAccess;
    using Microsoft.EntityFrameworkCore;

    public class EFPersistenceBuilder : IPersistenceBuilder
    {
        private static EFPersistenceBuilder instance;
        private readonly DALSettings _setting;

        private EFPersistenceBuilder(DALSettings settings)
        {
            _setting = settings ?? throw new DataAccessLayerException(nameof(settings));
        }

        public void BuildConfiguration(DbContextOptionsBuilder options)
        {
            //Uncomment if you want to apply LazyLoading globally and skip including it manually for each entity.
            //options.UseLazyLoadingProxies();
            options.EnableDetailedErrors(_setting.EnableDetailedDebug is true);
            options.EnableSensitiveDataLogging(_setting.EnableDetailedDebug is true);
            options.UseQueryTrackingBehavior(QueryTrackingBehavior.TrackAll);

            if (_setting.UseDatabase is true)
            {
                options.UseSqlServer(_setting.DatabaseConnection, dbOpt =>
                {
                    dbOpt.MigrationsHistoryTable("Migrations", "CONFIG");
                });
            }
            else
            {
                options.UseInMemoryDatabase(_setting.DatabaseName);
            }
        }

        public static IPersistenceBuilder Build(DALSettings settings)
        {
            if (instance == null)
                instance = new EFPersistenceBuilder(settings);

            return instance;
        }
    }
}
