/// <summary>
/// 
/// </summary>
namespace SchoolMngr.BackOffice.Model.Dtos
{
    using Codeit.NetStdLibrary.Base.Abstractions.DomainModel;
    using Reinforced.Typings.Attributes;
    using System;
    using System.Collections.Generic;

    [TsInterface(AutoI = false, Name = "Teacher", IncludeNamespace = false)]
    public sealed class TeacherDto : IDto
    {
        public TeacherDto()
        {
            Assingments = new List<AssingmentDto>();
        }

        public Guid Id { get; set; }
        public bool Deleted { get; set; }
        public string Address { get; set; }
        public bool IsTemporary { get; set; }
        public string Obs { get; set; }

        public ICollection<AssingmentDto> Assingments { get; set; }
    }
}
