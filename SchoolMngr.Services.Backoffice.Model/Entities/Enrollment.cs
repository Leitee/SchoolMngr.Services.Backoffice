
namespace SchoolMngr.Services.Backoffice.Model.Entities
{
    using Codeit.Enterprise.Base.DomainModel;
    using System;

    public class Enrollment : EFEntity
    {
        public string StudentProfileId { get; set; }

        public string StudentStatus { get; set; }

        public Guid ClassId { get; set; }
        public virtual Class Class { get; set; }
    }
}
