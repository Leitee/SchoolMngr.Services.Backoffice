
namespace SchoolMngr.Services.Backoffice.Model.Entities
{
    using Codeit.Enterprise.Base.Abstractions.DomainModel;
    using Codeit.Enterprise.Base.DomainModel;
    using System;
    using System.Collections.Generic;

    public class Teacher : EFEntity, IDeleteableEntity
    {
        public string EmployeeNumber { get; set; }
        public bool Deleted { get; set; }
        public string Address { get; set; }
        public bool IsTemporary { get; set; }
        public string Observations { get; set; }

        public Guid IdentityUserId { get; set; }

        public virtual ICollection<Assignment> Assingments { get; set; }

    }
}
