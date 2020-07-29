using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Pandora.NetStdLibrary.Base.DataAccess;
using System;
using System.IO;

namespace SchoolMngr.BackOffice.DAL
{
    public abstract class DesignTimeDbContextFactoryBase<TContext> :
        IDesignTimeDbContextFactory<TContext> where TContext : DbContext
    {
        private const string ConnectionStringName = "SchoolMngrMSvc";
        private const string AspNetCoreEnvironment = "ASPNETCORE_ENVIRONMENT";

        public TContext CreateDbContext(string[] args)
        {
            var basePath = Directory.GetCurrentDirectory(); //+ string.Format("{0}..{0}SchoolMngr.Services.BO", Path.DirectorySeparatorChar);
            return Create(basePath, Environment.GetEnvironmentVariable(AspNetCoreEnvironment) ?? "Development");//TODO: get varible from context
        }

        protected abstract TContext CreateNewInstance(DbContextOptions<TContext> options);

        private TContext Create(string basePath, string environmentName)
        {
            Console.WriteLine($"Entering create method with params[ basePath: '{basePath}', environmentName: '{environmentName}'].");

            var configuration = new ConfigurationBuilder()
                .SetBasePath(basePath)
                .AddJsonFile("appsettings.json")
                .AddJsonFile($"appsettings.{environmentName}.json", optional: true)
                .AddEnvironmentVariables()
                .Build();

            return Create(DALSettings.GetSettings(configuration).DatabaseUrl);
        }

        private TContext Create(string connectionString)
        {
            if (string.IsNullOrEmpty(connectionString))
            {
                throw new ArgumentException($"Connection string '{ConnectionStringName}' is null or empty.", nameof(connectionString));
            }

            Console.WriteLine($"DesignTimeDbContextFactoryBase.Create(string): Connection string: '{connectionString}'.");

            var optionsBuilder = new DbContextOptionsBuilder<TContext>();

            optionsBuilder.UseSqlServer(connectionString, sqlOpt =>
                    sqlOpt.MigrationsHistoryTable("Migrations", "Config"));

            return CreateNewInstance(optionsBuilder.Options);
        }
    }
}
