
namespace SchoolMngr.Services.Backoffice.Model.Entities
{
    using Codeit.NetStdLibrary.Base.DomainModel;
    using SchoolMngr.Services.Backoffice.Model.Enums;
    using System;

    public class Enrollment : EFEntity
    {
        public string StudentProfileId { get; set; }

        public StudentStatusEnum StudentStatus { get; set; }

        public Guid ClassId { get; set; }
        public virtual Class Class { get; set; }
    }
}
