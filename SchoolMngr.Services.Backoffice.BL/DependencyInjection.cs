
namespace SchoolMngr.Services.Backoffice.BL
{
    using FluentValidation;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Codeit.NetStdLibrary.Base.Abstractions.BusinessLogic;
    using Codeit.NetStdLibrary.Base.BusinessLogic;
    using SchoolMngr.Services.Backoffice.Model.Entities;
    using SchoolMngr.Services.Backoffice.BL.Dtos;
    using SchoolMngr.Services.Backoffice.BL.Mappers;
    using SchoolMngr.Services.Backoffice.BL.Abstractions;
    using SchoolMngr.Services.Backoffice.BL.Services;

    public static partial class DependencyInjection
    {
        public static IServiceCollection AddBusinessLogicTier(this IServiceCollection services, string sectionKey)
        {
            //var blSettings = BLSettings.GetSection(configuration ?? throw new BusinessLogicTierException(nameof(configuration)));

            //register validators
            //services.AddScoped<IValidator<CategoryDTO>, CreateCategoryValidator>();

            //services
            services.AddTransient<ISubjectSvc, SubjectSvc>();

            //mappers
            services.AddSingleton<IMapperCore, GenericMapper>();
            services.AddScoped<IMapperCore<Subject, SubjectDto>, SubjectMapper>();

            return services;
        }
    }
}
