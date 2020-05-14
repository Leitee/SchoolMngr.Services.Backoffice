/// <summary>
/// 
/// </summary>
namespace SchoolMngr.BackOffice.Model.Dtos
{
    using Pandora.NetStdLibrary.Base.Abstractions.DomainModel;
    using Reinforced.Typings.Attributes;
    using SchoolMngr.BackOffice.Model.Entities;
    using System;

    [TsInterface(AutoI = false, Name = "Assingment", IncludeNamespace = false)]
    public sealed class AssingmentDto : IDto
    {
        public DateTime StartsTime { get; set; }
        public DateTime EndsTime { get; set; }
        public TimeSpan Time { get { return EndsTime - StartsTime; } }
        public DayOfWeek Day { get { return StartsTime.DayOfWeek; } }

        public Subject Subject { get; set; }
        public Teacher Teacher { get; set; }
    }
}
