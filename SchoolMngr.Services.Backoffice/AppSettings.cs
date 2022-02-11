
namespace SchoolMngr.Services.Backoffice
{
    using Codeit.NetStdLibrary.Base.Common;
    using Codeit.NetStdLibrary.Base.DataAccess;
    using SchoolMngr.Infrastructure.Shared.Configuration;

    public class AppSettings : BaseSettings<AppSettings>
    {
        public const string DAL_SECTION_KEY = "DalSection";
        public const string INFRA_SECTION_KEY = "InfraSection";

        public DALSettings DalSection { get; set; }
        public INFRASettings InfraSection { get; set; }
    }
}
