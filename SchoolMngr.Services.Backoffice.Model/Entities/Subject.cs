
namespace SchoolMngr.Services.Backoffice.Model.Entities
{
    using Codeit.NetStdLibrary.Base.Abstractions.DomainModel;
    using Codeit.NetStdLibrary.Base.DomainModel;
    using System;
    using System.Collections.Generic;

    public class Subject : EFEntity, IDeleteableEntity
    {
        public string CodeName { get; set; }
        public string FullName { get; set; }
        public short MaxAbsencesAllowed { get; set; }
        public short MinExamScoreRequired { get; set; }
        public bool Deleted { get; set; }

        public Guid? NextAvailableId { get; set; }
        public virtual Subject NextAvailable { get; set; }

        public virtual ISet<Subject> PreviousRequired { get; set; }

        public int GradeId { get; set; }
        public virtual Grade Grade { get; set; }

        public virtual Class Class { get; set; }
    }
}
