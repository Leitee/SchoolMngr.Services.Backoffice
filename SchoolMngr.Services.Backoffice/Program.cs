
namespace SchoolMngr.Services.Backoffice
{
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    using SchoolMngr.Infrastructure.Shared.Configuration;
    using SchoolMngr.Services.Backoffice.DAL.Context;
    using Serilog;
    using System;

    public class Program
    {
        public static readonly string _appName = typeof(Program).Namespace;

        public static void Main(string[] args)
        {
            Log.Logger = SharedHostConfiguration.CreateSerilogLogger(_appName);

            Log.Debug($"Args passed: {string.Join(',', args) }");

            try
            {
                Log.Information("Configuring web host ({ApplicationContext})...", _appName);
                var host = Host
                    .CreateDefaultBuilder(args)
                    .ConfigureWebHostDefaults(wb => wb.UseStartup<Startup>())
                    .UseSerilog(Log.Logger)
                    .Build();

                if (Array.Exists(args, x => x.Contains("migrate")))
                {
                    Log.Debug("Applying migrations ({ApplicationContext})...", _appName);
                    using (var scope = host.Services.CreateScope())
                    {
                        var services = scope.ServiceProvider;

                        try
                        {
                            services
                                .GetRequiredService<BackofficeDbContext>()
                                .TryApplyMigration()
                                .TrySeedAll();
                        }
                        catch (Exception ex)
                        {
                            Log.Error(ex, "An error occurred while migrating or initializing the database.");
                        }
                    } 
                }

                Log.Information("Starting web host ({ApplicationContext})...", _appName);
                host.Run();
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Application failed at start up");
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }
    }
}
