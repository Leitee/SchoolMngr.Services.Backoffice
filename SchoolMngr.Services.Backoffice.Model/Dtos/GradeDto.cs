/// <summary>
/// 
/// </summary>
namespace SchoolMngr.BackOffice.Model.Dtos
{
    using Pandora.NetStdLibrary.Base.Abstractions.DomainModel;
    using Reinforced.Typings.Attributes;
    using System;

    [TsInterface(AutoI = false, Name = "Grade", IncludeNamespace = false)]
    public sealed class GradeDto : IDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
