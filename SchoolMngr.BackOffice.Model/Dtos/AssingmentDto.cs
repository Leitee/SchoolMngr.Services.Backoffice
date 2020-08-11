/// <summary>
/// 
/// </summary>
namespace SchoolMngr.BackOffice.Model.Dtos
{
    using Pandora.NetStdLibrary.Base.Abstractions.DomainModel;
    using Reinforced.Typings.Attributes;
    using System;

    [TsInterface(AutoI = false, Name = "Assingment", IncludeNamespace = false)]
    public sealed class AssingmentDto : IDto
    {
        public DateTime StartsTime { get; set; }
        public DateTime EndsTime { get; set; }
        public TimeSpan Duration { get { return EndsTime - StartsTime; } }
        public DayOfWeek Day { get { return StartsTime.DayOfWeek; } }

        public SubjectDto Subject { get; set; }
        public TeacherDto Teacher { get; set; }
    }
}
