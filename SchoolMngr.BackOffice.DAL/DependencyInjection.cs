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
                //Uncomment if you want to apply LazyLoading globally and skip to include it manually for each entity
                //optionsBuilder.UseLazyLoadingProxies();
                options.UseQueryTrackingBehavior(QueryTrackingBehavior.TrackAll);
                options.EnableDetailedErrors(dalSettings.IsDevelopment);
                options.EnableSensitiveDataLogging(dalSettings.IsDevelopment);
                options.UseNpgsql(dalSettings.DatabaseUrl, sqlOpt =>
                    {
                        sqlOpt.MigrationsHistoryTable("Migrations", "Config");
                    });
            });

            //services.AddScoped<SchoolDbContext>(provider => provider.GetService<SchoolDbContext>());

            return services;
        }
    }
}
