/// <summary>
/// /
/// </summary>
namespace SchoolMngr.BackOffice.DAL
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Pandora.NetStdLibrary.Base.DataAccess;

    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            var dalSettings = DALSettings.GetSettings(configuration ?? throw new DataAccessException(nameof(configuration)));

            services.AddDbContext<SchoolDbContext>(options =>
            {
                //If you want to apply LL globally and avoid to include manually on each entity
                //optionsBuilder.UseLazyLoadingProxies();
                options.UseQueryTrackingBehavior(QueryTrackingBehavior.TrackAll);
                options.EnableDetailedErrors(dalSettings.IsDevMode);
                options.EnableSensitiveDataLogging(dalSettings.IsDevMode);
                options.UseSqlServer(dalSettings.DatabaseUrl, sqlOpt =>
                    {
                        sqlOpt.MigrationsHistoryTable("Migrations", "Config");
                    });
            });

            //services.AddScoped<SchoolDbContext>(provider => provider.GetService<SchoolDbContext>());

            return services;
        }
    }
}
