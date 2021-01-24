using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using SchoolMngr.BackOffice.DAL;
using SchoolMngr.Infrastructure.Shared;
using SchoolMngr.Services.BO;
using Serilog;

namespace SchoolMngr.Services.BO
{
    public class Program
    {
        public static readonly string AppName = typeof(Program).Namespace;
        public static void Main(string[] args)
        {
            var configuration =  ProgramConfiguration.GetConfiguration();
            Log.Logger = ProgramConfiguration.CreateSerilogLogger(configuration, AppName);           

            try
            {
                Log.Information("Configuring web host ({ApplicationContext})...", AppName);
                var host = BuildWebHost(configuration, args);

                Log.Information("Applying migrations ({ApplicationContext})...", AppName);
                using (var scope = host.Services.CreateScope())
                {
                    var services = scope.ServiceProvider;

                    try
                    {
                        var northwindContext = services.GetRequiredService<SchoolDbContext>();
                        northwindContext.Database.Migrate();

                        //var identityContext = services.GetRequiredService<ApplicationDbContext>();
                        //identityContext.Database.Migrate();

                        //var mediator = services.GetRequiredService<IMediator>();
                        //await mediator.Send(new SeedSampleDataCommand(), CancellationToken.None);
                    }
                    catch (Exception ex)
                    {
                        var logger = services.GetRequiredService<ILogger<Program>>();
                        logger.LogError(ex, "An error occurred while migrating or initializing the database.");
                    }
                }


                Log.Information("Starting web host ({ApplicationContext})...", AppName);
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

        private static IWebHost BuildWebHost(IConfiguration configuration, string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .CaptureStartupErrors(true)
                .ConfigureAppConfiguration(x => x.AddConfiguration(configuration))
                .UseStartup<Startup>()
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseSerilog()
                .Build();
    }
}
