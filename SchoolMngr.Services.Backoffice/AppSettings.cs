
namespace SchoolMngr.Services.Backoffice
{
    using Codeit.Enterprise.Base.Common;
    using Codeit.Enterprise.Base.DataAccess;
    using SchoolMngr.Infrastructure.Shared.Configuration;

    public class AppSettings : BaseSettings<AppSettings>
    {
        public const string DAL_SECTION_KEY = "DalSection";
        public const string INFRA_SECTION_KEY = "InfraSection";

        public DALSettings DalSection { get; set; }
        public INFRASettings InfraSection { get; set; }
    }
}
