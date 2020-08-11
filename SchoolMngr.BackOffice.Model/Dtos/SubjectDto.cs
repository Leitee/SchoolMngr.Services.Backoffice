/// <summary>
/// 
/// </summary>
namespace SchoolMngr.BackOffice.Model.Dtos
{
    using Pandora.NetStdLibrary.Base.Abstractions.DomainModel;
    using Reinforced.Typings.Attributes;
    using SchoolMngr.BackOffice.Model.Entities;
    using System.Collections.Generic;

    [TsInterface(AutoI = false, Name = "Subject", IncludeNamespace = false)]
    public sealed class SubjectDto : IDto
    {
        public SubjectDto()
        {
            Assingments = new List<AssingmentDto>();
        }

        public string CodeName { get; set; }
        public string Description { get; set; }

        public SubjectDto Required { get; set; }
        public GradeDto Grade { get; set; }
        public ICollection<AssingmentDto> Assingments { get; set; }

    }
}
