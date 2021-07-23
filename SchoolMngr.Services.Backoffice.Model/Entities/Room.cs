/// <summary>
/// 
/// </summary>
namespace SchoolMngr.BackOffice.Model.Entities
{
    using Codeit.NetStdLibrary.Base.DomainModel;

    public class Room : EFEntity
    {
        public string Description { get; set; }
        public short Capacity { get; set; }
        public bool? HasNetworkConexion { get; set; }
        public bool? HasScreenProjector { get; set; }
    }
}
