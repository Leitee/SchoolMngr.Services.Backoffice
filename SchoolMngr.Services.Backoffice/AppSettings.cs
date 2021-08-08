
namespace SchoolMngr.Services.Backoffice
{
    using Codeit.NetStdLibrary.Base.Common;
    using Codeit.NetStdLibrary.Base.DataAccess;
    using SchoolMngr.Infrastructure.Shared.Configuration;

    public class AppSettings : BaseSettings<AppSettings>
    {
        public DALSettings DALSection { get; set; }
        public InfrastructureSettings InfrastructureSection { get; set; }
    }
}
