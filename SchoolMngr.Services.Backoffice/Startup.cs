
namespace SchoolMngr.Services.Backoffice
{
    using Codeit.Enterprise.Base.Application;
    using IdentityServer4.AccessTokenValidation;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Diagnostics.HealthChecks;
    using Microsoft.Extensions.Hosting;
    using Microsoft.Identity.Web;
    using Microsoft.OpenApi.Models;
    using SchoolMngr.Infrastructure.Shared;
    using SchoolMngr.Services.Backoffice.BL;
    using SchoolMngr.Services.Backoffice.DAL;
    using SchoolMngr.Services.Backoffice.DAL.Context;
    using Serilog;
    using System;
    using System.Collections.Generic;
    using System.Text.Json.Serialization;

    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services
                .AddOptions()
                .Configure<AppSettings>(Configuration);

            //services.Configure<AppSettings>(sttg =>
            //    Configuration.GetSection("").Bind(sttg);

            services.AddCors(options =>
            {
                options.AddDefaultPolicy(builder =>
                {
                    builder
                    .AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader();
                });
            });

            services
                .AddBusinessLogicLayer()
                .AddPersistenceLayer(AppSettings.DAL_SECTION_KEY)
                .AddInfrastructureLayer(AppSettings.INFRA_SECTION_KEY);

            services
                .AddControllersWithViews()
                .AddJsonOptions(opt => opt.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve);

            services
                .AddHealthChecks()
                .AddCheck("Self", _ => HealthCheckResult.Healthy())
                .AddDbContextCheck<BackofficeDbContext>();

            services
                .AddAuthorization(options =>
                {
                    // By default, all incoming requests will be authorized according to the default policy
                    options.FallbackPolicy = options.DefaultPolicy;
                })
                .AddAuthentication(IdentityServerAuthenticationDefaults.AuthenticationScheme)
                .AddIdentityServerAuthentication(options =>
                {
                    options.Authority = "https://localhost:7543";
                    options.ApiName = "backofficeAPI";
                });

            services
                .AddVersionedApiExplorer(o =>
                {
                    o.GroupNameFormat = "'v'VVV";
                    o.SubstituteApiVersionInUrl = true;
                });

            services
                .AddApiVersioning(opt =>
                {
                    opt.ReportApiVersions = true;
                    opt.AssumeDefaultVersionWhenUnspecified = true;
                    opt.DefaultApiVersion = new ApiVersion(1, 0);
                });

            services.AddSwaggerGen(options =>
            {
                //options.DescribeAllEnumsAsStrings();
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "SchoolMngr - Backoffice HTTP API",
                    Version = "v1",
                    Description = "Backoffice app for SchoolMngr solution"
                });
                options.AddSecurityDefinition("OAuth2", 
                    new OpenApiSecurityScheme
                    {
                        Type = SecuritySchemeType.OAuth2,
                    
                        Flows = new OpenApiOAuthFlows
                        {
                            ClientCredentials = new OpenApiOAuthFlow
                            //AuthorizationCode = new OpenApiOAuthFlow
                            {
                                AuthorizationUrl = new Uri("https://localhost:7543/connect/authorize"),
                                TokenUrl = new Uri("https://localhost:7543/connect/token"),
                                Scopes = new Dictionary<string, string>
                                {
                                    {"openid", "User profile"},
                                    {"backoffice", ""}
                                }
                            }
                        }
                    });
            });

            services
                .AddServerSideBlazor()
                .AddMicrosoftIdentityConsentHandler();

            services.AddRazorPages();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseIf(env.IsDevelopment(), app => app.UseDeveloperExceptionPage());
            app.UseIf(env.IsProduction(), app => app.UseExceptionHandler("/Error"));
            app.UseCustomExceptionHandler();

            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseIf(env.IsProduction(), app => app.UseHsts());

            //app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseSwagger();
            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(options =>
            {
                options.OAuthAppName("Codeit - IdentityServer");
                options.OAuthUseBasicAuthenticationWithAccessCodeGrant();
                options.OAuthClientId("backoffice-mvc");
                options.OAuthClientSecret("backoffice-secret");
                options.OAuthScopes("openid");
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "SchoolMngr.Backoffice V1");
            });

            // This will make the HTTP requests log as rich logs instead of plain text.
            app.UseSerilogRequestLogging();
            app.UseRouting();
            app.UseCors();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapHealthChecks("/hc");
                endpoints.MapControllers();
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
            });
        }
    }
}
