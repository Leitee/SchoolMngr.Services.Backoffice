/// <summary>
/// 
/// </summary>
namespace SchoolMngr.BackOffice.Model.Dtos
{
    using Codeit.NetStdLibrary.Base.Abstractions.DomainModel;
    using Reinforced.Typings.Attributes;
    using System;

    [TsInterface(AutoI = false, Name = "Room", IncludeNamespace = false)]
    public class RoomDto : IDto
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public short Capacity { get; set; }
        public bool? HasNetworkConexion { get; set; }
        public bool? HasScreenProjector { get; set; }
    }
}
