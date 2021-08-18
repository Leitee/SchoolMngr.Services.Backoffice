
namespace SchoolMngr.Services.Backoffice.BL.Dtos

{
    using Codeit.NetStdLibrary.Base.Abstractions.BusinessLogic;
    using System;
    using System.Collections.Generic;

    public sealed class SubjectDto : IDto
    {
        public SubjectDto()
        {
            Assingments = new List<AssignmentDto>();
            PreviousRequired = new List<SubjectDto>();
        }

        public Guid Id { get; set; }
        public string CodeName { get; set; }
        public string FullName { get; set; }
        public short MaxAbsencesAllowed { get; set; }
        public short MinExamScoreRequired { get; set; }
        public bool Deleted { get; set; }

        public Guid? NextAvailableId { get; set; }
        public SubjectDto NextAvailable { get; set; }

        public ICollection<SubjectDto> PreviousRequired { get; set; }

        public GradeDto Grade { get; set; }

        public ClassDto Class { get; set; }
        public ICollection<AssignmentDto> Assingments { get; set; }
    }
}
