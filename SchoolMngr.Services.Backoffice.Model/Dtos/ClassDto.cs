/// <summary>
/// 
/// </summary>
namespace SchoolMngr.BackOffice.Model.Dtos
{
    using Codeit.NetStdLibrary.Base.Abstractions.DomainModel;
    using Codeit.NetStdLibrary.Base.Common;
    using Codeit.NetStdLibrary.Base.Utils;
    using Reinforced.Typings.Attributes;
    using SchoolMngr.BackOffice.Model.Enums;
    using System;

    [TsInterface(AutoI = false, Name = "Class", IncludeNamespace = false)]
    public  sealed class ClassDto : IDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public ShiftTimeEnum Shift { get; set; }
        public string ShiftDescription { get { return Shift.GetDescription(); } }

        public AssingmentDto Assingment { get; set; }
        public RoomDto ClassRoom { get; set; }
    }
}
