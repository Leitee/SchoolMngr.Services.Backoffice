/// <summary>
/// 
/// </summary>
namespace SchoolMngr.BackOffice.Model.Dtos
{
    using Codeit.NetStdLibrary.Base.Abstractions.DomainModel;
    using Reinforced.Typings.Attributes;
    using SchoolMngr.BackOffice.Model.Entities;
    using System;
    using System.Collections.Generic;

    [TsInterface(AutoI = false, Name = "Subject", IncludeNamespace = false)]
    public sealed class SubjectDto : IDto
    {
        public SubjectDto()
        {
            Assingments = new List<AssingmentDto>();
        }

        public Guid Id { get; set; }
        public string CodeName { get; set; }
        public string Description { get; set; }

        public Subject Required { get; set; }
        public Grade Grade { get; set; }
        public ICollection<AssingmentDto> Assingments { get; set; }
    }
}
