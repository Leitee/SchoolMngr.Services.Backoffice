/// <summary>
/// 
/// </summary>
namespace SchoolMngr.BackOffice.Model.Dtos
{
    using Pandora.NetStdLibrary.Base.Abstractions.DomainModel;
    using Reinforced.Typings.Attributes;

    [TsInterface(AutoI = false, Name = "Room", IncludeNamespace = false)]
    public class RoomDto : IDto
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public short Capacity { get; set; }
        public bool? HasNetworkConexion { get; set; }
        public bool? HasScreenProjector { get; set; }
    }
}
