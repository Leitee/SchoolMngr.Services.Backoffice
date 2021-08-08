
namespace SchoolMngr.Services.Backoffice.DAL
{
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Codeit.NetStdLibrary.Base.DataAccess;
    using Codeit.NetStdLibrary.Base.Abstractions.DataAccess;
    using SchoolMngr.Services.Backoffice.DAL.Repository;
    using Codeit.NetStdLibrary.Base.Abstractions;
    using SchoolMngr.Services.Backoffice.DAL.Context;
    using System;

    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistenceLayer(this IServiceCollection services, string sectionKey)
        {
            DALSettings dalSettings;
            using (var servProv = services.BuildServiceProvider())
            {
                var config = servProv.GetService<IConfiguration>();
                dalSettings = config.GetSection(sectionKey).Get<DALSettings>();
            }

            if(dalSettings is null)
                throw new ArgumentNullException(nameof(dalSettings));

            services.Configure<DALSettings>(sp => sp = dalSettings);
            var efPersistenceBuilder = EFPersistenceBuilder.Build(dalSettings);

            //uow
            services
                .AddScoped<IApplicationUow, BackofficeUow>()
                .AddDbContext<BackofficeDbContext>(efPersistenceBuilder.BuildConfiguration);

            //repository
            services.AddScoped<IRepositoryProvider<BackofficeDbContext>, RepositoryProvider<BackofficeDbContext>>();
            services.AddSingleton<BackofficeRepositoryFactory>();

            return services;
        }
    }
}
